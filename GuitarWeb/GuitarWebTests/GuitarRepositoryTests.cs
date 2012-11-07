using System.Collections.Generic;
using GuitarWeb.Interfaces;
using GuitarWeb.Models;
using GuitarWeb.Repository;
using NUnit.Framework;
using System.Linq;

namespace GuitarWebTests
{
    [TestFixture]
    public class GuitarRepositoryTests
    {
        private readonly IGuitarRepository _guitarRepository = new GuitarRepository();

        [Test]
        public void ReadGuitars_ShouldReturnGuitars()
        {
            var guitars = _guitarRepository.GetGuitars();

            Assert.That(guitars.Count > 0);
        }

        [Test]
        public void SaveGuitars_Should_Find_Guitar_in_repository_after_save()
        {
            const string regNr = "123";
            var guitars = GetGuitars(regNr);

            _guitarRepository.SaveGuitars(guitars);

            var repositoryGuitars = _guitarRepository.GetGuitars();

            Assert.That(repositoryGuitars.Where(g => g.RegNumber == regNr).Any());
            
        }

        private List<Guitar> GetGuitars(string regNr)
        {
            return new List<Guitar>{new Guitar{RegNumber=regNr,Model="Gibson",ProductionYear = 1989}};
        }
    }
}
