using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCMusicStore.Controllers;
using MVCMusicStore.Models;
using MVCMusicStore.Test.Fakes;
using System.Web.Mvc;

namespace MVSMusicStore.Test
{
	/// <summary>
	/// Tên sản phẩm không hợp lệ
	/// </summary>
	[TestClass]
	public class StoreManagerControllerTest
	{

		[TestMethod]
		public void Create_Invalid_Album()
		{
			FakeDataStore dataStore = MusicStoreEntitiesFactory.GetEmpty();
			dataStore.GenerateAndAddGenre(1);
			dataStore.GenerateAndAddArtist(10);
			StoreManagerController controller = ControllerFactory.GetWiredUpController<StoreManagerController>((s) => new StoreManagerController(s), store: dataStore);
			Album album = new Album { Title = "~!@#$%^&*()_+{}:", Genre = new Genre { Name = "Rock" }, Price = 8.99M, Artist = new Artist { Name = "Men At Work" }, AlbumArtUrl = "/Content/Images/placeholder.gif" };
			RedirectToRouteResult result = controller.Create(album) as RedirectToRouteResult;
			Assert.IsTrue(result.RouteValues.ContainsValue("Index"));
		}

	}
}
