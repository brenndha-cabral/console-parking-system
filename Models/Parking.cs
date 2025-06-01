using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace console_parking_system.Models
{
    public class Parking
    {
        Dictionary<string, DateTime> carsOnParking = new Dictionary<string, DateTime> { };

        // Aceita placas antigas (ABC1234) e padrão Mercosul (ABC1D23) - No input para mascarar, está sendo normalizado para maiúsculo
        private bool IsValidPlate(string plate)
        {
            Regex regex = new Regex(@"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(plate);
        }

        public void RegisterCar()
        {
            Console.Write("Insira a placa do carro para cadastrar: ");

            string? newCar = Console.ReadLine()?.ToUpper();

            if (!string.IsNullOrEmpty(newCar) && IsValidPlate(newCar))
            {
                if (carsOnParking.ContainsKey(newCar))
                {
                    Console.WriteLine("⚠️ Este carro já está estacionado!");
                }
                else
                {
                    carsOnParking.Add(newCar, DateTime.Now);
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
            string? inputPlate = Console.ReadLine()?.ToUpper();

            if (!string.IsNullOrWhiteSpace(inputPlate) && IsValidPlate(inputPlate) && carsOnParking.ContainsKey(inputPlate))
            {
                DateTime registerTime = carsOnParking[inputPlate];
                Console.WriteLine($"✅ Carro encontrado! Placa: {inputPlate} | Entrada: {registerTime:dd/MM/yyyy HH:mm}");
            }
            else
            {
                Console.WriteLine("❌ Placa não encontrada.");
            }

        }

    }
}