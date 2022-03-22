using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Product.Commands.CreateProductCommand;
using LoanProcessManagement.Application.Features.Product.Commands.DeleteProductCommand;
using LoanProcessManagement.Application.Features.Product.Commands.UpdateProductCommand;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ApplicationDbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }

        public async Task<IEnumerable<LpmLoanProductMaster>> GetLoanProducts()
        {
            var loanProducts = await _dbContext.LpmLoanProductMasters.Where(x => x.ProductType == "L" && x.IsActive).ToListAsync();
            return loanProducts;
        }

        public async Task<IEnumerable<LpmLoanProductMaster>> GetInsuranceProducts()
        {
            var loanProducts = await _dbContext.LpmLoanProductMasters.Where(x => x.ProductType == "I" && x.IsActive).ToListAsync();
            return loanProducts;
        }

        public async Task<IEnumerable<LpmLoanProductMaster>> GetAllProducts()
        {
            return await _dbContext.LpmLoanProductMasters.ToListAsync();
        }

        public async Task<LpmLoanProductMaster> GetProductById(long id)
        {
            return await _dbContext.LpmLoanProductMasters.Include(x => x.LpmLoanProductSchemeMappings).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CreateProductCommandDto> CreateProduct(CreateProductCommand req)
        {
            CreateProductCommandDto res = new CreateProductCommandDto();

            var result = await _dbContext.LpmLoanProductMasters.FirstOrDefaultAsync(x => x.ProductName == req.ProductName && x.ProductType == req.ProductType && x.ProducDescription == req.ProducDescription);
            if (result != null)
            {
                res.Message = "Product already exists.";
                res.Succeeded = false;
                return res;

            }
            else
            {
                var newProduct = new LpmLoanProductMaster()
                {
                    ProductType = req.ProductType,
                    ProductName = req.ProductName,
                    ProducDescription = req.ProducDescription,
                    IsActive = true
                };
                await _dbContext.LpmLoanProductMasters.AddAsync(newProduct);
                await _dbContext.SaveChangesAsync();

                foreach (var x in req.Schemes)
                {
                    var newScheme = new LpmLoanProductSchemeMapping()
                    {
                        SchemeID = x,
                        ProductID = newProduct.Id,
                        IsActive = true

                    };
                    await _dbContext.LpmLoanProductSchemeMappings.AddAsync(newScheme);

                }
                await _dbContext.SaveChangesAsync();
                res.Message = "Product Added Successfully.";
                res.Succeeded = true;
                return res;
            }
        }

        public async Task<DeleteProductCommandDto> DeleteProduct(long id)
        {
            DeleteProductCommandDto res = new DeleteProductCommandDto();
            var result = await _dbContext.LpmLoanProductMasters.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                //_dbContext.LpmBranchMasters.Remove(result);
                await _dbContext.SaveChangesAsync();
                res.Message = $"Product removed successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Invalid Id.";
                res.Succeeded = false;
            }
            return res;
        }

        public async Task<UpdateProductCommandDto> UpdateProduct(UpdateProductCommand req)
        {
            UpdateProductCommandDto response = new UpdateProductCommandDto();
            var result = await _dbContext.LpmLoanProductMasters.FirstOrDefaultAsync(x => x.ProductName == req.ProductName && x.ProducDescription == req.ProducDescription
            && x.ProductType == req.ProductType && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Product already exists.";
                response.Succeeded = false;
                return response;

            }
            var productToUpdate = await _dbContext.LpmLoanProductMasters.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (productToUpdate != null)
            {
                productToUpdate.ProductType = req.ProductType;
                productToUpdate.ProductName = req.ProductName;
                productToUpdate.ProducDescription = req.ProducDescription;
                productToUpdate.IsActive = req.IsActive;
                _dbContext.LpmLoanProductSchemeMappings.Where(x => x.ProductID == req.Id).ToList().ForEach(x => _dbContext.LpmLoanProductSchemeMappings.Remove(x));
                foreach (var x in req.Schemes)
                {
                    var newScheme = new LpmLoanProductSchemeMapping()
                    {
                        SchemeID = x,
                        ProductID = req.Id,
                        IsActive = true

                    };
                    await _dbContext.LpmLoanProductSchemeMappings.AddAsync(newScheme);

                }
                await _dbContext.SaveChangesAsync();

                response.Message = "Product updated successfully.";
                response.Succeeded = true;
                return response;

            }
            else
            {
                response.Message = "Invalid Id.";
                response.Succeeded = true;
                return response;
            }
        }
    }
}
