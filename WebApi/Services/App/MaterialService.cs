using WebApi.Models.DBModels;
using WebApi.Models.ParamModels;
using WebApi.Models.Views.App;
using WebApi.Repositories.Interfaces;
using WebApi.Services.Interfaces.App;

namespace WebApi.Services.App
{
    /// <summary>
    /// 材料業務服務實作
    /// </summary>
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        /// <inheritdoc />
        public async Task<List<MaterialView>> GetAllAsync()
        {
            try
            {
                var materials = await _materialRepository.GetAllMaterialsAsync();
                return materials.Select(m => new MaterialView
                {
                    Id = m.Id,
                    Name = m.Type,
                    Brand = m.Brand,
                    Specification = m.Model,
                    Price = m.Price,
                    InventoryQuantity = m.Quantity
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving materials.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<MaterialView> GetByIdAsync(int id)
        {
            try
            {
                var material = await _materialRepository.GetMaterialByIdAsync(id);
                if (material == null)
                {
                    throw new Exception($"Material with ID {id} not found.");
                }

                return new MaterialView
                {
                    Id = material.Id,
                    Name = material.Type,
                    Brand = material.Brand,
                    Specification = material.Model,
                    Price = material.Price,
                    InventoryQuantity = material.Quantity
                };
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving material.", ex);
            }
        }

        /// <inheritdoc />
        public async Task CreateAsync(CreateMaterialParam param)
        {
            try
            {
                var product = new Product
                {
                    Name = param.Name,
                    Brand = param.Brand,
                    Specification = param.Specification,
                    Price = param.Price,
                    InventoryQuantity = param.InventoryQuantity
                };

                await _materialRepository.AddMaterialAsync(product);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating material.", ex);
            }
        }

        /// <inheritdoc />
        public async Task UpdateAsync(UpdateMaterialParam param)
        {
            try
            {
                var existingMaterial = await _materialRepository.GetMaterialByIdAsync(param.Id);
                if (existingMaterial == null)
                {
                    throw new Exception($"Material with ID {param.Id} not found.");
                }

                var product = new Product
                {
                    Id = param.Id,
                    Name = param.Name ?? existingMaterial.Type,
                    Brand = param.Brand ?? existingMaterial.Brand,
                    Specification = param.Specification ?? existingMaterial.Model,
                    Price = param.Price ?? existingMaterial.Price,
                    InventoryQuantity = param.InventoryQuantity ?? existingMaterial.Quantity
                };

                await _materialRepository.UpdateMaterialAsync(product);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating material.", ex);
            }
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            try
            {
                var material = await _materialRepository.GetMaterialByIdAsync(id);
                if (material == null)
                {
                    throw new Exception($"Material with ID {id} not found.");
                }

                await _materialRepository.DeleteMaterialAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting material.", ex);
            }
        }
    }
}
