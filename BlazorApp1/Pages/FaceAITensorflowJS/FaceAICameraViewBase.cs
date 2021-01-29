using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages.FaceAITensorflowJS
{
    public class FaceAICameraViewBase:ComponentBase
    {
        [Inject]
        IJSRuntime js { get; set; }


        IJSObjectReference jSObject;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {

                    jSObject = await js.InvokeAsync<IJSObjectReference>("import", "./FaceAICameraView.js");

                    await jSObject.InvokeVoidAsync("Initialize");

                }
                catch (Exception ex)
                {
                    await js.InvokeVoidAsync("JSAlert", ex.Message);
                    return;
                }
            }

        }
        protected async void btnClick()
        {
            await jSObject.InvokeVoidAsync("Initialize");
        }

    }
}
