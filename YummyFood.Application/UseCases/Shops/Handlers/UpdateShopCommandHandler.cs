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
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateShopCommandHandler(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            var shop = await _context.Shops.FindAsync(request.Id, cancellationToken) ?? throw new _404NotFoundException("Shop not found!"); ;

            try
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
                        throw new ErrorPostingImage(ex.Message.ToString());
                    }


                    try
                    {
                        File.Delete(shop.Photo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        File.Delete(shop.PreviewPhoto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    shop.Name = request.Name;
                    shop.Status = request.Status;
                    shop.AddressId = request.AddressId;
                    shop.Description = request.Description;
                    shop.PhoneNumber = request.PhoneNumber;
                    shop.Photo = "/ShopPhotos/" + fileName;
                    shop.PreviewPhoto = "/ShopPreviewPhotos/" + fileName2;
                    shop.TimeTableWeekend = request.TimeTableWeekend;
                    shop.TimeTableWeekday = request.TimeTableWeekday;
                    shop.ModifiedAt = DateTimeOffset.UtcNow;

                    _context.Shops.Update(shop);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel()
                    {
                        IsSuccess = true,
                        Message = "Successfully Updated",
                        StatusCode = 200,
                    };
                }
                else
                {
                    throw new RequestNullException("Request is null here.");
                }
            }

            catch (Exception ex)
            {
                throw new ErrorUpdatingData(ex.Message.ToString());
            }
        }
    }
}
