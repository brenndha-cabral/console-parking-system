using console_parking_system.Models;

Parking parking = new Parking();
bool keepRun = true;

Dictionary<int, string> menu = new Dictionary<int, string>
{
    { 1, "Cadastrar Carro" },
    { 2, "Remover Carro" },
    { 3, "Listar Carros" },
    { 4, "Encontrar Carro" },
    { 5, "Encerrar Programa!" },
};

while (keepRun)
{
    Console.WriteLine("⚠️  ESCOLHA UMA OPÇÃO ⚠️");

    foreach (KeyValuePair<int, string> option in menu)
    {
        Console.WriteLine($"{option.Key} - {option.Value}");
    }

    int input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {
        case 1:
            parking.RegisterCar();
            break;

        case 2:
            parking.RemoveCar();
            break;

        case 3:
            parking.ListCar();
            break;

        case 4:
            parking.FindCar();
            break;

        case 5:
            parking.ExitProgram();
            keepRun = false;
            break;

        default:
            Console.WriteLine("⚠️ Opção inválida.");
            break;
    }
}



