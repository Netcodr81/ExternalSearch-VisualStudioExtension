using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace ExternalSearch
{
    [Guid("4fd36e8d-6da6-4bdb-a5e1-baa345bc3cdb")]
    public class ExternalSearchOptionPage : DialogPage
    {
        private const string defaultUrl = "https://www.bing.com/search?q={0}";

        private static Dictionary<SearchEngines, string> allEngines = new Dictionary<SearchEngines, string>()
        {
            {SearchEngines.Bing, defaultUrl },
            {SearchEngines.Google, "https://www.google.com/search?q={0}" },
            {SearchEngines.MSDN, "https://docs.microsoft.com/en-in/search/?search={0}&category=All" },
            {SearchEngines.StackOverflow, "https://stackoverflow.com/search?q={0}" }
        };

        [DisplayName("Search Engine")]
        [DefaultValue("Bing")]
        [Category("General")]
        [Description("The Search Engine to be used for searching")]
        [TypeConverter(typeof(EnumConverter))]
        public SearchEngines SearchEngine { get; set; } = SearchEngines.Bing;

        [DisplayName("Url")]
        [Category("General")]
        [Description("The Search Engine url to be used for searching")]
        [Browsable(false)]
        public string Url
        {
            get
            {
                var selectedEngineUrl = allEngines.FirstOrDefault(j => j.Key == SearchEngine).Value;
                return string.IsNullOrWhiteSpace(selectedEngineUrl) ? defaultUrl : selectedEngineUrl;
            }
        }
    }

    public enum SearchEngines
    {
        Bing = 0,
        Google,
        MSDN,
        StackOverflow
    }
}
