using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace console_parking_system.Models
{
    public class Parking
    {
        Dictionary<string, DateTime> carsOnParking = new Dictionary<string, DateTime>{};
        
        // Aceita placas antigas (ABC1234) e padrão Mercosul (ABC1D23) - No input para mascarar, está sendo normalizado para maiúsculo
        private bool IsValidPlate(string plate)
        {
            Regex regex = new Regex(@"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(plate);
        }
    }
}