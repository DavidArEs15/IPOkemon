﻿#pragma checksum "C:\Users\david\Desktop\David UNI\TERCERO-TI\2 Cuatrimestre\IPO 2\Lab\Proyecto Grupal Pokedex\Ipokemon\Ipokemon (1)\IPOkemon\Lab5\PokedexPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1CE85F34E1F44C73161C85DEE7124F823C26F08B51597C3909D1E2B439E6AD48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab5
{
    partial class PokedexPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // PokedexPage.xaml line 1
                {
                    this.Pokedex = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2: // PokedexPage.xaml line 17
                {
                    this.imgFondo1 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3: // PokedexPage.xaml line 18
                {
                    this.mucTeddiursa = (global::Lab5.MUCPokemonOso)(target);
                }
                break;
            case 4: // PokedexPage.xaml line 19
                {
                    this.imgFondo2 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 5: // PokedexPage.xaml line 24
                {
                    this.mucSableye = (global::Lab5.MUCPokemonSableye)(target);
                }
                break;
            case 6: // PokedexPage.xaml line 25
                {
                    this.mucCastform = (global::Lab5.MUCCastform)(target);
                }
                break;
            case 7: // PokedexPage.xaml line 26
                {
                    this.mucPiplup = (global::Lab5.MUCPinguino)(target);
                }
                break;
            case 8: // PokedexPage.xaml line 27
                {
                    this.btnInfoOso = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnInfoOso).Click += this.btnInfoOso_Click;
                }
                break;
            case 9: // PokedexPage.xaml line 35
                {
                    this.btnInfoSableye = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnInfoSableye).Click += this.btnInfoSableye_Click;
                }
                break;
            case 10: // PokedexPage.xaml line 43
                {
                    this.btnInfoCastform = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnInfoCastform).Click += this.btnInfoCastform_Click;
                }
                break;
            case 11: // PokedexPage.xaml line 51
                {
                    this.btnInfoPiplup = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnInfoPiplup).Click += this.btnInfoPiplup_Click;
                }
                break;
            case 12: // PokedexPage.xaml line 59
                {
                    this.tbTeddiursa = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // PokedexPage.xaml line 60
                {
                    this.tbSableye = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // PokedexPage.xaml line 61
                {
                    this.tbCastform = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // PokedexPage.xaml line 62
                {
                    this.tbPiplup = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // PokedexPage.xaml line 64
                {
                    this.imgAumentar = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)this.imgAumentar).PointerReleased += this.imgAumentar_PointerReleased;
                }
                break;
            case 17: // PokedexPage.xaml line 65
                {
                    this.imgDisminuir = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)this.imgDisminuir).PointerReleased += this.imgDisminuir_PointerReleased;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
