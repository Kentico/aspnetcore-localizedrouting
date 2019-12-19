using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kentico.Kontent.AspNetCore.LocalizedRouting.TagHelpers
{
    [HtmlTargetElement("a", Attributes = ActionAttributeName)]
    [HtmlTargetElement("a", Attributes = ControllerAttributeName)]
    [HtmlTargetElement("a", Attributes = AreaAttributeName)]
    [HtmlTargetElement("a", Attributes = PageAttributeName)]
    [HtmlTargetElement("a", Attributes = PageHandlerAttributeName)]
    [HtmlTargetElement("a", Attributes = FragmentAttributeName)]
    [HtmlTargetElement("a", Attributes = HostAttributeName)]
    [HtmlTargetElement("a", Attributes = ProtocolAttributeName)]
    [HtmlTargetElement("a", Attributes = RouteAttributeName)]
    [HtmlTargetElement("a", Attributes = RouteValuesDictionaryName)]
    [HtmlTargetElement("a", Attributes = RouteValuesPrefix + "*")]
    public class TranslatedAnchorTagHelper : AnchorTagHelper
    {
        private const string ActionAttributeName = "asp-action";
        private const string ControllerAttributeName = "asp-controller";
        private const string AreaAttributeName = "asp-area";
        private const string PageAttributeName = "asp-page";
        private const string PageHandlerAttributeName = "asp-page-handler";
        private const string FragmentAttributeName = "asp-fragment";
        private const string HostAttributeName = "asp-host";
        private const string ProtocolAttributeName = "asp-protocol";
        private const string RouteAttributeName = "asp-route";
        private const string RouteValuesDictionaryName = "asp-all-route-data";
        private const string RouteValuesPrefix = "asp-route-";

        private readonly IActionContextAccessor contextAccessor;
        private readonly ITranslatedService translatedService;

        public TranslatedAnchorTagHelper(IHtmlGenerator generator, IActionContextAccessor contextAccessor, ITranslatedService translatedService) : base(generator)
        {
            this.contextAccessor = contextAccessor;
            this.translatedService = translatedService;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var culture = contextAccessor.ActionContext.RouteData.Values["culture"].ToString();

            Controller = translatedService.ResolveLinks(culture, Controller);
            Action = translatedService.ResolveLinks(culture, Action);

            return base.ProcessAsync(context, output);
        }
    }
}
