using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MarketPlaces.Dtos;
using MarketPlaces.Models;
using Microsoft.AspNet.Identity;

namespace MarketPlaces.Controllers
{
    //[Authorize]
    //public class AttendancesController : ApiController
    //{
       
    //    private ApplicationDbContext _context;

    //    public AttendancesController()
    //    {
    //        _context = new ApplicationDbContext();
    //    }
    //        [HttpPost]
    //        public IHttpActionResult Attend(AttendanceDto dto)
    //        {
    //            var userId = User.Identity.GetUserId();

    //            if (_context.Attendances.Any((a => a.AttendeeId == userId && a.MarketId == dto.MarketId)))
    //            return BadRequest("The attendance already exists.");
           
    //        var attendance = new Attendance
    //            {
    //                MarketId = dto.MarketId,
    //                AttendeeId = userId
                   
    //            };
    //            _context.Attendances.Add(attendance);
    //            _context.SaveChanges();
    //            return Ok();
    //        }
    //}
}
