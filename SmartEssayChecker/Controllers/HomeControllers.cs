// ===================================================
// Copyright (c) Coalition of Good-Hearted programmers
// Developed by Cash Overflow devs
// ===================================================

using Microsoft.AspNetCore.Mvc;

namespace SmartEssayChecker;



[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Get() => "Cash flows...";
}