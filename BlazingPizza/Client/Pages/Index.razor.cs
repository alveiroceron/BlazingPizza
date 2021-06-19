using BlazingPizza.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingPizza.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        #region Variables
        List<PizzaSpecial> Specials;
        Pizza ConfiguringPizza;
        bool ShowingConfigureDialog;
        #endregion

        #region overrides
        protected async override Task OnInitializedAsync()
        {
            Specials = await HttpClient.GetFromJsonAsync<List<PizzaSpecial>>("specials");
        }
        #endregion

        #region Metodos
        void ShowConfigPizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>()
            };
            ShowingConfigureDialog = true;
        }

        #endregion
    }
}
