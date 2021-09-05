using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRD.Infrastructure
{
    // Вспомагательная функция дескриптора для визуализации навигационного меню приложения
    [HtmlTargetElement("navmenu", Attributes = "elements")]
    public class NavMenuTagHelper : TagHelper
    {
        // Элементы меню (контроллер, наименование)
        public (string, string)[] Elements { get; set; }
        // Текущий контроллер
        public string Controller { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            foreach (var (controller, label) in Elements)
            {
                TagBuilder a = new("a");
                output.Content.AppendHtml(a);
                a.InnerHtml.Append(label);
                a.Attributes.Add("href", $"/{controller}");
                a.AddCssClass("btn w-100 m-1");
                a.AddCssClass(controller == Controller ? "btn-danger" : "btn-secondary");
            }
        }
    }
}