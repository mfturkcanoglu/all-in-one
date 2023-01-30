using AlIInOne.Dtos;
using AlIInOne.Models;
using AlIInOne.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlIInOne.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly ILessonService _service;
    private readonly IMapper _mapper;

    public LessonController(ILessonService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await _service.GetById(id));

    [HttpPost("createLesson")]
    public async Task<IActionResult> CreateLessonForSemester([FromForm] LessonCreateDto lessonCreateDto)
    {
        return CreatedAtAction(nameof(CreateLessonForSemester), await _service.CreateForSemester(lessonCreateDto));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LessonCreateDto dto)
    {
        var lesson = _mapper.Map<Lesson>(dto);
        return CreatedAtAction(nameof(Create), await _service.Create(lesson));
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] LessonUpdateDto dto)
    {
        var lesson = _mapper.Map<Lesson>(dto);
        return Ok(await _service.Update(lesson));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) => Ok(await _service.Delete(id));
}

