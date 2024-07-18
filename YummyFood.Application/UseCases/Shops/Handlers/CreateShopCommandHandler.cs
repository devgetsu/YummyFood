using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Shops.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Shops.Handlers
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateShopCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                var file = request.Photo;
                var file2 = request.PreviewPhoto;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ShopPhotos");
                string fileName = "";

                string filePath2 = Path.Combine(_webHostEnvironment.WebRootPath, "ShopPreviewPhotos");
                string fileName2 = "";

                try
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                        Debug.WriteLine("Directory created successfully.");
                    }

                    if (!Directory.Exists(filePath2))
                    {
                        Directory.CreateDirectory(filePath2);
                        Debug.WriteLine("Directory created successfully.");
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ShopPhotos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    fileName2 = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath2 = Path.Combine(_webHostEnvironment.WebRootPath, "ShopPreviewPhotos", fileName);
                    using (var stream = new FileStream(filePath2, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                catch (Exception ex)
                {
                    return new ResponseModel()
                    {
                        IsSuccess = false,
                        StatusCode = 500,
                        Message = ex.Message,
                    };
                }

                var address = new Address()
                {
                    Letitude = request.Letitude,
                    Longitude = request.Longitude,
                };

                await _context.Addresses.AddAsync(address, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);


                var shop = new Shop()
                {
                    Rate = 0,
                    Name = request.Name,
                    Status = request.Status,
                    AddressId = address.Id,
                    Description = request.Description,
                    PhoneNumber = request.PhoneNumber,
                    Photo = "/ShopPhotos/" + fileName,
                    PreviewPhoto = "/ShopPreviewPhotos/" + fileName2,
                    TimeTableWeekend = request.TimeTableWeekend,
                    TimeTableWeekday = request.TimeTableWeekday,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                await _context.Shops.AddAsync(shop, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    Message = "Created",
                    IsSuccess = true,
                    StatusCode = 201
                };
            }
            else
            {
                throw new RequestNullException("Request is null here!");
            }
        }
    }
}
