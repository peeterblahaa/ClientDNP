// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ClientDNP.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using ClientDNP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/_Imports.razor"
using ClientDNP.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/Pages/AdultsList.razor"
using ClientDNP.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/Pages/AdultsList.razor"
using ClientDNP.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/list")]
    public partial class AdultsList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 96 "/Users/peterblasko/RiderProjects/ClientDNP/ClientDNP/Pages/AdultsList.razor"
       


    private IList<Adult> adultsToShow;
    private IList<Adult> allAdults;
    private string[] adultProperties =  { "Id", "First Name", "Last Name","Age"};
    
    private string selectedFilter;
    


    


    


    protected override async Task OnInitializedAsync()
    {
        allAdults = await AdultsData.GetAdults();
        adultsToShow = allAdults;
        StateHasChanged();
    }

    private void RemoveAdult(int adultId)
    {
        var toRemove = allAdults.First(a => a.Id == adultId);
        allAdults.Remove(toRemove);
        adultsToShow.Remove(toRemove);
        AdultsData.RemoveAdult(toRemove);
    }
    
    
    
    
    private void ChangeFilter(ChangeEventArgs arg)
    {
        selectedFilter = arg.Value.ToString();
        adultsToShow = allAdults;
    }

    private void Filter(ChangeEventArgs arg)
    {
        switch (selectedFilter)
        {
            case "Id":
                int? filterById = null;
                try
                {
                    filterById = int.Parse(arg.Value.ToString());
                }
                catch (Exception e) { Console.WriteLine(e); }
                if (filterById != null)
                {
                    adultsToShow = allAdults.Where(adult => adult.Id == filterById).ToList();
                }
                else adultsToShow = allAdults;
                break;
            case "Age":
                int? filterByAge = null;
                try
                {
                    filterByAge = int.Parse(arg.Value.ToString());
                }
                catch (Exception e) { Console.WriteLine(e); }
                if (filterByAge != null)
                {
                    adultsToShow = allAdults.Where(adult => adult.Age == filterByAge).ToList();
                }
                else adultsToShow = allAdults;
                break;
            
            case "First Name":
                if (arg.Value.ToString() != null)
                {
                    adultsToShow = allAdults.Where(adult => adult.FirstName.Contains(arg.Value.ToString())).ToList();
                }
                else adultsToShow = allAdults;
                break;
            case "Last Name":
                if (arg.Value.ToString() != null)
                {
                    adultsToShow = allAdults.Where(adult => adult.LastName.Contains(arg.Value.ToString())).ToList();
                }
                else adultsToShow = allAdults;
                break;
        }
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavMgr { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAdultData AdultsData { get; set; }
    }
}
#pragma warning restore 1591
