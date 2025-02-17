using Microsoft.AspNetCore.Mvc;
using UniHub.DTOs;
using UniHub.Interfaces.Services;
using UniHub.Models;

namespace UniHub.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IPostService _postService;

    public UserController(IUserService userService, IPostService postService)
    {
        _userService = userService;
        _postService = postService;
    } 
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _postService.GetAllPosts();
        if (!response.Status) return View("Error", new ErrorViewModel
        {
            Message = response.Message
        });


        return View(response.Data);
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LogInUserRequestModel model)
    {
        await _userService.LogIn(model);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpUserRequestModel model)
    {
        await _userService.SignUp(model);
        return RedirectToAction("Register");
    }
    
    [HttpGet]
    public IActionResult RegisterUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserRequestModel model)
    {
        await _userService.RegisterUser(model);
        return RedirectToAction("Index");
    }
}