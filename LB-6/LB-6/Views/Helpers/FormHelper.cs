using System;
using System.Web.Mvc;

namespace LB_6.Views.Helpers
{
    public static class FormHelper
    {
        private const string UpdateAction = "UpdateSave";

        public static MvcHtmlString RenderForm(this HtmlHelper htmlPage, string endpointType, string actionType, object model = null)
        {
            var isUpdate = string.Equals(actionType, UpdateAction, StringComparison.OrdinalIgnoreCase);

            var tagBuilder = new TagBuilder("form");
            tagBuilder.MergeAttribute("method", "post");
            tagBuilder.MergeAttribute("action", endpointType);

            var nameInput = new TagBuilder("input");
            nameInput.MergeAttribute("type", "text");
            nameInput.MergeAttribute("name", "Name");
            if (isUpdate)
            {
                nameInput.MergeAttribute("value", endpointType.Contains("Sql") ? (model as SQL.DAL.Models.PhoneContact)?.Name : (model as JSON.DAL.Models.PhoneContact)?.Name);
            }
            tagBuilder.InnerHtml += nameInput.ToString();

            var phoneInput = new TagBuilder("input");
            phoneInput.MergeAttribute("type", "text");
            phoneInput.MergeAttribute("name", "Phone");
            if (isUpdate)
            {
                phoneInput.MergeAttribute("value", endpointType.Contains("Sql") ? (model as SQL.DAL.Models.PhoneContact)?.Phone : (model as JSON.DAL.Models.PhoneContact)?.Phone);
            }
            tagBuilder.InnerHtml += phoneInput.ToString();

            if (isUpdate)
            {
                var idInput = new TagBuilder("input");
                idInput.MergeAttribute("type", "hidden");
                idInput.MergeAttribute("name", "Id");
                idInput.MergeAttribute("value", endpointType.Contains("Sql") ? (model as SQL.DAL.Models.PhoneContact)?.Id.ToString() : (model as JSON.DAL.Models.PhoneContact)?.Id.ToString());
                tagBuilder.InnerHtml += idInput.ToString();
            }

            var submitButton = new TagBuilder("input");
            submitButton.MergeAttribute("type", "submit");
            tagBuilder.InnerHtml += submitButton.ToString();

            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}