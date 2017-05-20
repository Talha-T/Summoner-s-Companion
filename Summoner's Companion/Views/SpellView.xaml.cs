using System;
using System.Text.RegularExpressions;
using System.Windows;
using Newtonsoft.Json.Linq;
using RiotSharp.StaticDataEndpoint;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// SpellView.xaml etkileşim mantığı
    /// </summary>
    public partial class SpellView
    {
        public SpellView()
        {
            InitializeComponent();
            Loaded += delegate
            {
                var text = SpellDesc.Text;
                var index = 0;
                const string pattern = @"{{\s*e\d+\s*}}";
                var result = Regex.Replace(text, pattern, m => Spell.EffectBurns[++index]);
                var aIndex = 0;
                const string aPattern = @"{{\s*(a|f)\d+\s*}}";

                var aResult = Regex.Replace(result, aPattern,
                    m =>
                    {
                        try
                        {
                            var coeff = Spell.Vars[aIndex++];
                            return ListToString((JArray) coeff.Coeff) + (coeff.Link == "spelldamage"
                                       ? " AP"
                                       : coeff.Link == "bonusattackdamage" || coeff.Link == "attackdamage"
                                           ? " AD"
                                           : "Not Implemented");
                        }
                        catch
                        {
                            return m.Value;
                        }
                    });
                SpellDesc.Text = aResult;
                
                if (SpellCost.Text.StartsWith("Cost: 0"))
                {
                    SpellCost.Text = SpellCost.Text.Remove(SpellCost.Text.IndexOf("0", StringComparison.Ordinal), 1);
                }
            };
        }

        private string ListToString(JArray list)
        {
            string str = null;
            foreach (var x in list)
            {
                str += $@"\{x}";
            }
            return str.Substring(1);
        }

        public ChampionSpellStatic Spell
        {
            get => (ChampionSpellStatic)GetValue(SpellProperty);
            set => SetValue(SpellProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpellProperty =
            DependencyProperty.Register("Spell", typeof(ChampionSpellStatic), typeof(SpellView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, SpellChangedCallback));

        private static void SpellChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = (SpellView) d;
            view.Spell = (ChampionSpellStatic) e.NewValue; 
        }

        public string SpellString
        {
            get => (string)GetValue(SpellStringProperty);
            set => SetValue(SpellStringProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpellStringProperty =
            DependencyProperty.Register("SpellString", typeof(string), typeof(SpellView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, SpellStringChangedCallback));

        private static void SpellStringChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = (SpellView)d;
            view.SpellString = (string)e.NewValue;
        }

    }
}
