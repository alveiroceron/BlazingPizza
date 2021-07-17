using BlazingPizza.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BlazingPizza.Client.Pages
{
    public partial class OrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }


        OrderWithStatus OrderWithStatus;

        bool InvalidOrder;

        CancellationTokenSource PollingCancelationtoken;

        protected override void OnParametersSet()
        {
            PollingCancelationtoken?.Cancel();
            PollForUpdate();
        }

        private async void PollForUpdate()
        {
            PollingCancelationtoken = new CancellationTokenSource();

            while (!PollingCancelationtoken.IsCancellationRequested)
            {
                try
                {
                    InvalidOrder = false;
                    OrderWithStatus = await HttpClient
                        .GetFromJsonAsync<OrderWithStatus>($"orders/{OrderId}");
                    StateHasChanged();
                    if (OrderWithStatus.IsDelivered)
                    {
                        PollingCancelationtoken.Cancel();
                    }
                    else {
                        await Task.Delay(4000);
                    }
                }
                catch (Exception ex)
                {
                    InvalidOrder = true;
                    PollingCancelationtoken.Cancel();
                    Console.Error.WriteLine(ex);
                    StateHasChanged();
                }          
            }
        }

        public void Dispose()
        {
            PollingCancelationtoken?.Cancel();
        }


    }
}
