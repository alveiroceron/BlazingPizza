using BlazingPizza.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingPizza.Client.Pages
{
    public partial class Checkout
    {
        [Inject]
        public OrderState OrderState { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        bool isSubmiting;
       
        async Task PlaceOrder()
        {
            isSubmiting = true;

            try
            {          
                    var Response = await HttpClient.PostAsJsonAsync("orders", OrderState.Order);
                    var NewOrderId = await Response.Content.ReadFromJsonAsync<int>();
                    OrderState.ResetOrder();
                    NavigationManager.NavigateTo($"myorders/{NewOrderId}");               
            }
            finally
            {
                isSubmiting = false;
            }
        }
    }
}
