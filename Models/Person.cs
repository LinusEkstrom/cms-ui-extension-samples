
using EPiServer.Core;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UIExtensionSamples.Models
{
    public class Person
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        //TODO: Investigate why saving or loading of list does not work.
        //[AllowedTypes(typeof(PageData))]
        //public IList<ContentReference> FavoritePages { get; set; }

        /// <summary>
        /// You can of course add custom methods to your sub model classes.
        /// </summary>
        public int GetAge()
        {
            var years = DateTime.Now.Year - DateOfBirth.Year;
            if(DateOfBirth.DayOfYear >= DateTime.Now.DayOfYear)
            {
                years++;
            }
            return years;
        }
    }
}