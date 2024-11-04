using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.DTOs.Vehicle
{
    public class VehicleTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Economy, Business, SUV gibi araç türü adı
        public string Description { get; set; } // Tür hakkında açıklama
        public bool IsDeleted { get; set; }
    }
}
