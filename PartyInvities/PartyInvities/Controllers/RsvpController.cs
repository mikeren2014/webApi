using PartyInvities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartyInvities.Controllers
{
    public class RsvpController : ApiController
    {
        public IEnumerable<GuestResponse> GetAttendees()
        {
            return Repository.Responses.Where(x => x.WillAttend == true);
        }

        public void PostResponse(GuestResponse response)
        {
            if (ModelState.IsValid)
            {
                Repository.Add(response);
            }
        }
    }
}
