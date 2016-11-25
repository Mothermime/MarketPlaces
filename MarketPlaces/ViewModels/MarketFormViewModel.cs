using MarketPlaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;
using MarketPlaces.Controllers;
using System.Linq.Expressions;

namespace MarketPlaces.ViewModels
{
    //The view model pattern "provide clean separtation between UI and domain"
    public class MarketFormViewModel
    {

        //Serverside validation
        public int Id { get; set; }
        public string Organiser { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public string Heading { get; set; }

        public string Action {
            get
            {//lambda expression takes 'c' as an argument and returns an actionresult  func is a delegate to represent that - the first input ('Markets controller') is the first input to that anonymous method, the second argument is the return type - 'Actionresult'. 'Func' is a delegate which allows the ananymous method but it doesn't need to call it, just to represent it as an expression and so it gets changed to Expression of func of marketscontroller.  
               // This espression now represents the update method/action in the Markets controller
                Expression<Func<MarketsController, ActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<MarketsController, ActionResult>> create =
                    (c => c.Create(this));
                //depending on the value of the id one of these expressions will be selected and from there will come the method name at run time
                // i.e. if the Id is not 0 update will be selected, otherwise, create
                //the var is also and expression
                var action = (Id != 0) ? update : create;
                // with this the method can be extracted at run time
                //cast 'Body' to MethodCallExpression because this expression represents a methodcall like create or update.  
                //From a methodcallexpression access to a method property is gained and then .Name
                return (action.Body as MethodCallExpression).Method.Name;
                //This way of writing the code eliminates the below line which is termed 'magic strings' - hard coded terms.
               // return (Id != 0) ? "Update" : "Create";
            }
        }
        

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }


    }
}


