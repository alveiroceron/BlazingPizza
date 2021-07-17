using BlazingPizza.Client.Services;
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
        #region Servicios

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public OrderState OrderState { get; set; }

        #endregion


        #region Variables
        List<PizzaSpecial> Specials;
    
        #endregion

        #region overrides
        protected async override Task OnInitializedAsync()
        {
            Specials = await HttpClient.GetFromJsonAsync<List<PizzaSpecial>>("specials");
        }
        #endregion

        #region Metodos
       

        #endregion

        #region Manejador Eventos
        

       

       

        async Task PlaceOrder()
        {
            var Response = await HttpClient.PostAsJsonAsync("orders", OrderState.Order );
            var NewOrderId = await Response.Content.ReadFromJsonAsync<int>();
            OrderState.ResetOrder();
            NavigationManager.NavigateTo($"myorders/{NewOrderId}");
        }

        #endregion
    }
}
