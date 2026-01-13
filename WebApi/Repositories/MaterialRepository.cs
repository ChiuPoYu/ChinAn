using Microsoft.EntityFrameworkCore;
using WebApi.Models.DBModels;
using WebApi.Models.ViewModels.App;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    /// <summary>
    /// 材料資料的資料存取實作
    /// </summary>
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<List<MaterailViewModel>> GetAllMaterialsAsync()
        {
            return await _context.Set<Product>()
                .Select(p => new MaterailViewModel
                {
                    Id = p.Id,
                    Type = p.Name,
                    Brand = p.Brand,
                    Model = p.Specification,
                    Price = p.Price,
                    Quantity = p.InventoryQuantity,
                    ImageUrl = string.Empty
                })
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<MaterailViewModel?> GetMaterialByIdAsync(int id)
        {
            return await _context.Set<Product>()
                .Where(p => p.Id == id)
                .Select(p => new MaterailViewModel
                {
                    Id = p.Id,
                    Type = p.Name,
                    Brand = p.Brand,
                    Model = p.Specification,
                    Price = p.Price,
                    Quantity = p.InventoryQuantity,
                    ImageUrl = string.Empty
                })
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task AddMaterialAsync(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateMaterialAsync(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteMaterialAsync(int id)
        {
            var product = await _context.Set<Product>().FindAsync(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
