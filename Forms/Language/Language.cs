namespace Forms
{
    using Configuration;

    public class Language
    {
        public static string CurrentCulture
        {
            get { return InputLanguage.CurrentInputLanguage.Culture.Name; }
            set { throw new NotImplementedException("Later"); }
        }

        public static LanguageConfig CurrentLanguage
        {
            get
            {
                var cur = CurrentCulture;
                if (Config.Now.Mappings.TryGetValue(cur, out var lang_str))
                {
                    if (Config.Now.Languages.ContainsKey(lang_str))
                    {
                        return Config.Now.Languages[lang_str];
                    }
                    else
                        throw new IncorrectConfigException($"No language '{lang_str}' ");
                }
                else
                {
                    throw new IncorrectConfigException($"No mapping for {cur} :: {CurrentCulture} :: {InputLanguage.CurrentInputLanguage.LayoutName}");
                }
            }
            set { throw new NotImplementedException(""); }
        }
    }
}
