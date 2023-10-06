using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Models.Dto;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepo _platformRepo;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepo platformRepo, IMapper mapper)
    {
        _platformRepo = platformRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformRepo>> GetPlatforms()
    {
        Console.WriteLine("--> Getting Platforms...");
        var platformItem = _platformRepo.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }

    [HttpGet("{id}")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platformItem = _platformRepo.GetPlatformById(id);
        if (platformItem == null)
            return NotFound();
        
        return Ok(_mapper.Map<PlatformReadDto>(platformItem));
    }
}