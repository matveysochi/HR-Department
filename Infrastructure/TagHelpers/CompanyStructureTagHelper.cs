using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRD.Models;

namespace HRD.Infrastructure
{
    // Вспомагательная функция дескриптора для визуализации иерархической структуры организации
    [HtmlTargetElement("company", Attributes = "structure")]
    public class CompanyStructureTagHelper : TagHelper
    {
        // Структура организации в формате словаря
        // ключ:        Родительское подразделение
        // значение:    Перечисление подчиненных отделов
        public Dictionary<Division, IEnumerable<Division>> Structure { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder rootTag = new("div");
            // Корневое родительское подразделение по соглашению не храниться в базе,
            // а создается и добавляется в полученную выборку искуственно с Id = 0 
            Division rootDivision = Structure.Keys.FirstOrDefault(div => div.Id == 0);

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.AppendHtml("Организация");
            output.Content.AppendHtml(rootTag);

            // Генерируем html разметку структуры организации с помощью рекурсивной функции
            if (rootDivision != null)
                GenerateOrganizationTreeHtml(rootTag, rootDivision);
            else
                rootTag.InnerHtml.Append("Нет корневых отделов!");
        }
        
        // Рекурсивная функия построения "дерева организации"
        void GenerateOrganizationTreeHtml(TagBuilder rootTag, Division rootDivision)
        {
            TagBuilder ul = new ("ul");
            foreach (var division in Structure[rootDivision])
            {
                TagBuilder li = new ("li");
                li.InnerHtml.Append(division.Name);
                ul.InnerHtml.AppendHtml(li);
                if (Structure.ContainsKey(division))
                {
                    GenerateOrganizationTreeHtml(li, division);
                }
            }
            rootTag.InnerHtml.AppendHtml(ul);
        }
    }
}