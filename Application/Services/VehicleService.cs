using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services
{
    public class VehicleService : IBaseService<Vehicle>
    {
        private readonly IBaseRepository<Vehicle> _vehicleRepository;

        public VehicleService(IBaseRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }


        public async Task<Vehicle> CreateAsync(Vehicle vehicle, CancellationToken token = default)
        {
            return await _vehicleRepository.CreateAsync(vehicle, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var vehicle = await _vehicleRepository.GetAsync(id, token);

            if (vehicle == null)
                return false;

            return await _vehicleRepository.DeleteAsync(vehicle, token);
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken token = default)
        {
            return await _vehicleRepository.GetAllAsync(token);
        }

        public async Task<Vehicle> GetAsync(int id, CancellationToken token = default)
        {
            return await _vehicleRepository.GetAsync(id, token);
        }
        public async Task<bool> UpdateAsync(Vehicle vehicles, CancellationToken token = default)
        {
            var existingVehicle = await GetAsync(vehicles.Id);

            if (existingVehicle is null)
            {
                return false;
            }

            existingVehicle.Type = vehicles.Type;
            existingVehicle.NumberPlate = vehicles.NumberPlate;
            



            return await _vehicleRepository.UpdateAsync(existingVehicle, token);

        }
    }
}
