using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace console_parking_system.Models
{
    public class Parking
    {
        Dictionary<string, DateTime> carsOnParking = new Dictionary<string, DateTime> { };

        Dictionary<int, decimal> values = new Dictionary<int, decimal>
        {
            { 1, 10M },
            { 2, 15M },
            { 3, 20M },
            { 4, 25M },
            { 5, 30M },
        };

        Dictionary<int, string> paymentMethods = new Dictionary<int, string>
        {
            { 1, "Pix" },
            { 2, "Crédito" },
            { 3, "Débito" },
            { 4, "Dinheiro" },
        };

        // Aceita placas antigas (ABC1234) e padrão Mercosul (ABC1D23) - No input para mascarar, está sendo normalizado para maiúsculo
        private bool IsValidPlate(string plate)
        {
            Regex regex = new Regex(@"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(plate);
        }

        private decimal CalculateValueOfTime(double hours)
        {
            int roundedHours = (int)Math.Ceiling(hours);

            if (values.TryGetValue(roundedHours, out decimal hourValue))
            {
                return (decimal)hours * hourValue;
            }
            else
            {
                return (decimal)hours * values[values.Keys.Max()];
            }
        }

        public void RegisterCar()
        {
            Console.Write("Insira a placa do carro para cadastrar: ");

            string? car = Console.ReadLine()?.ToUpper();

            if (!string.IsNullOrEmpty(car) && IsValidPlate(car))
            {
                if (carsOnParking.ContainsKey(car))
                {
                    Console.WriteLine("⚠️ Este carro já está estacionado!");
                }
                else
                {
                    carsOnParking.Add(car, DateTime.Now);
                    Console.WriteLine("✅ Carro cadastrado com sucesso.");
                }
            }
            else
            {
                Console.WriteLine("❌ Placa inválida ou nula!");
            }

        }

        public void ListCar()
        {

            if (carsOnParking.Count == 0)
            {
                Console.WriteLine("🚗 Nenhum carro estacionado.");
            }
            else
            {
                Console.WriteLine("🚗 Carros no estacionamento:");

                foreach (KeyValuePair<string, DateTime> car in carsOnParking)
                {
                    Console.WriteLine($"Placa: {car.Key} | Entrada: {car.Value:dd/MM/yyyy HH:mm}");
                }
            }

        }

        public void FindCar()
        {
            Console.Write("Digite a placa para buscar: ");
            string? car = Console.ReadLine()?.ToUpper();

            if (!string.IsNullOrWhiteSpace(car) && IsValidPlate(car) && carsOnParking.ContainsKey(car))
            {
                DateTime registerTime = carsOnParking[car];
                Console.WriteLine($"✅ Carro encontrado! Placa: {car} | Entrada: {registerTime:dd/MM/yyyy HH:mm}");
            }
            else
            {
                Console.WriteLine("❌ Placa não encontrada.");
            }

        }

        public void RemoveCar()
        {
            Console.Write("Digite a placa para buscar e remover: ");
            string? car = Console.ReadLine()?.ToUpper();

            if (!string.IsNullOrWhiteSpace(car) && IsValidPlate(car) && carsOnParking.ContainsKey(car))
            {
                DateTime registerTime = carsOnParking[car];
                DateTime departureTime = DateTime.Now;
                TimeSpan parkedTime = registerTime - departureTime;
                double betweenOfHours = parkedTime.TotalHours;
                string payValue = CalculateValueOfTime(betweenOfHours).ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

                Console.WriteLine($"⏳ Tempo: {betweenOfHours} - 💰 Total a pagar: {payValue}");
                Console.WriteLine("Qual a forma de pagamento?");

                foreach (KeyValuePair<int, string> payment in paymentMethods)
                {
                    Console.WriteLine($"{payment.Key} - {payment.Value}");
                }

                int InputMethodPayment = Convert.ToInt32(Console.ReadLine());

                if (!paymentMethods.ContainsKey(InputMethodPayment))
                {
                    Console.WriteLine("❌ Opção não encontrada.");
                }
                else
                {
                    Console.WriteLine($"✅ Método de pagamento: {paymentMethods[InputMethodPayment]} - 💰 Total a pagar: {payValue}");
                }

                Console.Write("Pagamento efetuado? (S/N): ");
                ConsoleKeyInfo isPaid = Console.ReadKey();

                if (isPaid.Key == ConsoleKey.S)
                {
                    carsOnParking.Remove(car);
                    Console.WriteLine("✅ Carro liberado.");
                }
                else if (isPaid.Key == ConsoleKey.N)
                {
                    Console.WriteLine("❌ Carro não liberado.");
                }
                else
                {
                    Console.WriteLine("⚠️ Opção inválida.");
                }

            }
            else
            {
                Console.WriteLine("❌ Placa não encontrada.");
            }
        }

        public void ExitProgram()
        {
            Console.Write("Programa Finalizado!");
        }
    }
}