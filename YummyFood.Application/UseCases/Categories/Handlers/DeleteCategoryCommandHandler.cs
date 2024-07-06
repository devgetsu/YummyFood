
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Categories.Commands;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteCategoryCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            if (category == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Category not found.",
                    StatusCode = 404
                };
            }
            try
            {
                File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, category.Sticker));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Category Removed.",
                StatusCode = 200
            };
        }
    }
