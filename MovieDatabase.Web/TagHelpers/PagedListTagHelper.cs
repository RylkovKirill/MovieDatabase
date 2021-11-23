using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MovieDatabase.Common.Paging;
using System.Collections.Generic;

namespace MovieDatabase.Web.TagHelpers
{
    public class PagedListTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _factory;

        public PagedListTagHelper(IUrlHelperFactory factory)
        {
            _factory = factory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagedListBase Model { get; set; }
        public string Action { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "action-")]
        public Dictionary<string, object> ActionValues { get; set; } = new();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = _factory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            var tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            if (Model.Page > 1)
            {
                tag.InnerHtml.AppendHtml(CreateTag(urlHelper, 1));
            }

            if (Model.CanPrevious && Model.Page - 1 > 1)
            {
                if (Model.Page - 2 > 1)
                {
                    var pageNumber = 1 + ((Model.Page - 2)) / 2;
                    tag.InnerHtml.AppendHtml(CreateTag(urlHelper, pageNumber, "..."));
                }
                tag.InnerHtml.AppendHtml(CreateTag(urlHelper, Model.Page - 1));
            }

            tag.InnerHtml.AppendHtml(CreateTag(urlHelper, Model.Page));

            if (Model.CanNext && Model.Page + 1 < Model.TotalPages)
            {
                tag.InnerHtml.AppendHtml(CreateTag(urlHelper, Model.Page + 1));
                if (Model.Page + 2 < Model.TotalPages)
                {
                    var pageNumber = (Model.Page + 1) + (Model.TotalPages - (Model.Page + 1)) / 2;
                    tag.InnerHtml.AppendHtml(CreateTag(urlHelper, pageNumber, "..."));
                }
            }

            if (Model.Page < Model.TotalPages)
            {
                tag.InnerHtml.AppendHtml(CreateTag(urlHelper, Model.TotalPages));
            }

            output.Content.AppendHtml(tag);
        }

        private TagBuilder CreateTag(IUrlHelper urlHelper, int value, string view = null)
        {
            var item = new TagBuilder("li");
            var link = new TagBuilder("a");

            if (value == Model.Page)
            {
                item.AddCssClass("active");
            }
            else
            {
                ActionValues["page"] = value;
                link.Attributes["href"] = urlHelper.Action(Action, ActionValues);
            }

            item.AddCssClass("page-item");
            link.AddCssClass("page-link");

            link.InnerHtml.Append(view ?? value.ToString());
            item.InnerHtml.AppendHtml(link);

            return item;
        }
    }
}
