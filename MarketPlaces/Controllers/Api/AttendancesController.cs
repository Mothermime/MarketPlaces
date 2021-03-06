﻿using System.Linq;
using System.Web.Http;
using MarketPlaces.Dtos;
using MarketPlaces.Models;
using Microsoft.AspNet.Identity;

namespace MarketPlaces.Controllers.Api
{
    //web API 2 Controller - Empty Restrict Api to authorised users.
    //The first time this is used, the line GlobalConfiguration.Configure(WebApiConfig.Register); needs to be added to the Global asax.cs file at the beginning of the Application_Start method and import the namespace


    [Authorize]
   
    public class AttendancesController : ApiController
 //When moving a file from one folder to another, use the refactoring 'move' function rather than dragging and dropping as it will automatically updates the namespace
    {

        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            // check if there is an attendance object for the current user for the given market
            if (_context.Attendances.Any((a => a.AttendeeId == userId && a.MarketId == dto.MarketId)))
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                MarketId = dto.MarketId,
                AttendeeId = userId
              //todo Work out how to order this by the date.  This doesn't give the .noatation .OrderBy(m => m.)
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
