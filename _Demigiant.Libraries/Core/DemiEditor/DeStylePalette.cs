﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2015/04/29 18:54

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

#pragma warning disable 1591
namespace DG.DemiEditor
{
    /// <summary>
    /// Stores a GUIStyle palette, which can be passed to default DeGUI layouts when calling <code>DeGUI.BeginGUI</code>,
    /// and changed at any time by calling <code>DeGUI.ChangePalette</code>.
    /// You can inherit from this class to create custom GUIStyle palettes with more options.
    /// Each of the sub-options require a public Init method to initialize the styles, which will be called via Reflection.
    /// </summary>
    public class DeStylePalette
    {
        public readonly BoxStyles box = new BoxStyles();
        public readonly ButtonStyles button = new ButtonStyles();
        public readonly LabelStyles label = new LabelStyles();
        public readonly ToolbarStyles toolbar = new ToolbarStyles();
        public readonly MiscStyles misc = new MiscStyles();

        protected bool initialized;

        // ADB path to Imgs directory, final slash included
        static string _adbImgsDir {
            get { if (_fooAdbImgsDir == null) _fooAdbImgsDir = Assembly.GetExecutingAssembly().ADBDir() + "/Imgs/"; return _fooAdbImgsDir; }
        }
        static string _fooAdbImgsDir;

        #region Texture2D

        public static Texture2D whiteSquare { get { return LoadTexture(ref _whiteSquare, "whiteSquare"); } }
        public static Texture2D whiteSquareAlpha10 { get { return LoadTexture(ref _whiteSquareAlpha10, "whiteSquareAlpha10"); } }
        public static Texture2D whiteSquareAlpha15 { get { return LoadTexture(ref _whiteSquareAlpha15, "whiteSquareAlpha15"); } }
        public static Texture2D whiteSquareAlpha25 { get { return LoadTexture(ref _whiteSquareAlpha25, "whiteSquareAlpha25"); } }
        public static Texture2D whiteSquareAlpha50 { get { return LoadTexture(ref _whiteSquareAlpha50, "whiteSquareAlpha50"); } }
        public static Texture2D whiteSquareAlpha80 { get { return LoadTexture(ref _whiteSquareAlpha80, "whiteSquareAlpha80"); } }
        public static Texture2D whiteSquare_fadeOut_bt { get { return LoadTexture(ref _whiteSquare_fadeOut_bt, "whiteSquare_fadeOut_bt", FilterMode.Bilinear); } }
        public static Texture2D blackSquare { get { return LoadTexture(ref _blackSquare, "blackSquare"); } }
        public static Texture2D blackSquareAlpha10 { get { return LoadTexture(ref _blackSquareAlpha10, "blackSquareAlpha10"); } }
        public static Texture2D blackSquareAlpha15 { get { return LoadTexture(ref _blackSquareAlpha15, "blackSquareAlpha15"); } }
        public static Texture2D blackSquareAlpha25 { get { return LoadTexture(ref _blackSquareAlpha25, "blackSquareAlpha25"); } }
        public static Texture2D blackSquareAlpha50 { get { return LoadTexture(ref _blackSquareAlpha50, "blackSquareAlpha50"); } }
        public static Texture2D blackSquareAlpha80 { get { return LoadTexture(ref _blackSquareAlpha80, "blackSquareAlpha80"); } }
        public static Texture2D redSquare { get { return LoadTexture(ref _redSquare, "redSquare"); } }
        public static Texture2D orangeSquare { get { return LoadTexture(ref _orangeSquare, "orangeSquare"); } }
        public static Texture2D yellowSquare { get { return LoadTexture(ref _yellowSquare, "yellowSquare"); } }
        public static Texture2D greenSquare { get { return LoadTexture(ref _greenSquare, "greenSquare"); } }
        public static Texture2D blueSquare { get { return LoadTexture(ref _blueSquare, "blueSquare"); } }
        public static Texture2D purpleSquare { get { return LoadTexture(ref _purpleSquare, "purpleSquare"); } }
        public static Texture2D squareBorder { get { return LoadTexture(ref _squareBorder, "squareBorder"); } }
        public static Texture2D squareBorderEmpty01 { get { return LoadTexture(ref _squareBorderEmpty01, "squareBorderEmpty01"); } }
        public static Texture2D squareBorderEmpty02 { get { return LoadTexture(ref _squareBorderEmpty02, "squareBorderEmpty02"); } }
        public static Texture2D squareBorderEmpty03 { get { return LoadTexture(ref _squareBorderEmpty03, "squareBorderEmpty03"); } }
        public static Texture2D squareBorderAlpha15 { get { return LoadTexture(ref _squareBorderAlpha15, "squareBorderAlpha15"); } }
        public static Texture2D squareBorderCurved { get { return LoadTexture(ref _squareBorderCurved, "squareBorderCurved"); } }
        public static Texture2D squareBorderCurvedEmpty { get { return LoadTexture(ref _squareBorderCurvedEmpty, "squareBorderCurvedEmpty"); } }
        public static Texture2D squareBorderCurvedEmptyThick { get { return LoadTexture(ref _squareBorderCurvedEmptyThick, "squareBorderCurvedEmptyThick"); } }
        public static Texture2D squareBorderCurvedEmpty02 { get { return LoadTexture(ref _squareBorderCurvedEmpty02, "squareBorderCurvedEmpty02"); } }
        public static Texture2D squareBorderCurvedAlpha { get { return LoadTexture(ref _squareBorderCurvedAlpha, "squareBorderCurvedAlpha"); } }
        public static Texture2D squareBorderCurved_darkBordersAlpha { get { return LoadTexture(ref _squareBorderCurved_darkBordersAlpha, "squareBorderCurved_darkBordersAlpha"); } }
        public static Texture2D squareCornersEmpty02 { get { return LoadTexture(ref _squareCornersEmpty02, "squareCornersEmpty02"); } }
        public static Texture2D whiteDot { get { return LoadTexture(ref _whiteDot, "whiteDot"); } }
        public static Texture2D whiteDot_darkBorder { get { return LoadTexture(ref _whiteDot_darkBorder, "whiteDot_darkBorder"); } }
        public static Texture2D whiteDot_whiteBorderAlpha { get { return LoadTexture(ref _whiteDot_whiteBorderAlpha, "whiteDot_whiteBorderAlpha"); } }
        public static Texture2D circle { get { return LoadTexture(ref _circle, "circle", FilterMode.Bilinear); } }
        static Texture2D _whiteSquare;
        static Texture2D _whiteSquareAlpha10;
        static Texture2D _whiteSquareAlpha15;
        static Texture2D _whiteSquareAlpha25;
        static Texture2D _whiteSquareAlpha50;
        static Texture2D _whiteSquareAlpha80;
        static Texture2D _whiteSquare_fadeOut_bt; // Bottom to top
        static Texture2D _blackSquare;
        static Texture2D _blackSquareAlpha10;
        static Texture2D _blackSquareAlpha15;
        static Texture2D _blackSquareAlpha25;
        static Texture2D _blackSquareAlpha50;
        static Texture2D _blackSquareAlpha80;
        static Texture2D _redSquare;
        static Texture2D _orangeSquare;
        static Texture2D _yellowSquare;
        static Texture2D _greenSquare;
        static Texture2D _blueSquare;
        static Texture2D _purpleSquare;
        static Texture2D _squareBorder;
        static Texture2D _squareBorderEmpty01;
        static Texture2D _squareBorderEmpty02;
        static Texture2D _squareBorderEmpty03;
        static Texture2D _squareBorderAlpha15;
        static Texture2D _squareBorderCurved;
        static Texture2D _squareBorderCurvedEmpty;
        static Texture2D _squareBorderCurvedEmptyThick;
        static Texture2D _squareBorderCurvedEmpty02; // More curved
        static Texture2D _squareBorderCurvedAlpha;
        static Texture2D _squareBorderCurved_darkBordersAlpha;
        static Texture2D _squareCornersEmpty02;
        static Texture2D _whiteDot;
        static Texture2D _whiteDot_darkBorder;
        static Texture2D _whiteDot_whiteBorderAlpha;
        static Texture2D _circle;
        public static Texture2D ico_nodeArrow { get { return LoadTexture(ref _ico_nodeArrow, "ico_nodeArrow", FilterMode.Bilinear, 16); } }
        public static Texture2D ico_end { get { return LoadTexture(ref _ico_end, "ico_end", FilterMode.Bilinear); } }
        public static Texture2D ico_alignTL { get { return LoadTexture(ref _ico_alignTL, "ico_alignTL"); } }
        public static Texture2D ico_alignTC { get { return LoadTexture(ref _ico_alignTC, "ico_alignTC"); } }
        public static Texture2D ico_alignTR { get { return LoadTexture(ref _ico_alignTR, "ico_alignTR"); } }
        public static Texture2D ico_alignCL { get { return LoadTexture(ref _ico_alignCL, "ico_alignCL"); } }
        public static Texture2D ico_alignCC { get { return LoadTexture(ref _ico_alignCC, "ico_alignCC"); } }
        public static Texture2D ico_alignCR { get { return LoadTexture(ref _ico_alignCR, "ico_alignCR"); } }
        public static Texture2D ico_alignBL { get { return LoadTexture(ref _ico_alignBL, "ico_alignBL"); } }
        public static Texture2D ico_alignBC { get { return LoadTexture(ref _ico_alignBC, "ico_alignBC"); } }
        public static Texture2D ico_alignBR { get { return LoadTexture(ref _ico_alignBR, "ico_alignBR"); } }
        public static Texture2D ico_star { get { return LoadTexture(ref _ico_star, "ico_star"); } }
        public static Texture2D ico_star_border { get { return LoadTexture(ref _ico_star_border, "ico_star_border"); } }
        public static Texture2D ico_play { get { return LoadTexture(ref _ico_play, "ico_play"); } }
        public static Texture2D ico_play_border { get { return LoadTexture(ref _ico_play_border, "ico_play_border"); } }
        public static Texture2D ico_cog { get { return LoadTexture(ref _ico_cog, "ico_cog"); } }
        public static Texture2D ico_cog_border { get { return LoadTexture(ref _ico_cog_border, "ico_cog_border"); } }
        public static Texture2D ico_comment { get { return LoadTexture(ref _ico_comment, "ico_comment"); } }
        public static Texture2D ico_comment_border { get { return LoadTexture(ref _ico_comment_border, "ico_comment_border"); } }
        public static Texture2D ico_ui { get { return LoadTexture(ref _ico_ui, "ico_ui"); } }
        public static Texture2D ico_ui_border { get { return LoadTexture(ref _ico_ui_border, "ico_ui_border"); } }
        public static Texture2D grid_dark { get { return LoadTexture(ref _grid_dark, "grid_dark", FilterMode.Point, 64, TextureWrapMode.Repeat); } }
        public static Texture2D grid_bright { get { return LoadTexture(ref _grid_bright, "grid_bright", FilterMode.Point, 64, TextureWrapMode.Repeat); } }
        static Texture2D _ico_nodeArrow;
        static Texture2D _ico_end;
        static Texture2D _ico_alignTL;
        static Texture2D _ico_alignTC;
        static Texture2D _ico_alignTR;
        static Texture2D _ico_alignCL;
        static Texture2D _ico_alignCC;
        static Texture2D _ico_alignCR;
        static Texture2D _ico_alignBL;
        static Texture2D _ico_alignBC;
        static Texture2D _ico_alignBR;
        static Texture2D _ico_star;
        static Texture2D _ico_star_border;
        static Texture2D _ico_cog;
        static Texture2D _ico_cog_border;
        static Texture2D _ico_play;
        static Texture2D _ico_play_border;
        static Texture2D _ico_comment;
        static Texture2D _ico_comment_border;
        static Texture2D _ico_ui;
        static Texture2D _ico_ui_border;
        static Texture2D _grid_dark;
        static Texture2D _grid_bright;

        #endregion

        /// <summary>
        /// Called automatically by <code>DeGUI.BeginGUI</code>.
        /// Override when adding new style subclasses.
        /// </summary>
        internal void Init()
        {
            if (initialized) return;

            initialized = true;

            // Default inits (made manually so they happen before subpalettes, which might be using them)
            box.Init();
            button.Init();
            label.Init();
            toolbar.Init();
            misc.Init();

            // Initialize custome subpalettes from inherited classes
            FieldInfo[] fieldInfos = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo fi in fieldInfos) {
                if (fi.FieldType.IsSubclassOf(typeof(DeStyleSubPalette))) ((DeStyleSubPalette)fi.GetValue(this)).Init();
            }
        }

        static Texture2D LoadTexture(ref Texture2D property, string name, FilterMode filterMode = FilterMode.Point, int maxTextureSize = 32, TextureWrapMode wrapMode = TextureWrapMode.Clamp)
        {
            if (property == null) {
                property = AssetDatabase.LoadAssetAtPath(String.Format("{0}{1}.png", _adbImgsDir, name), typeof(Texture2D)) as Texture2D;
                property.SetGUIFormat(filterMode, maxTextureSize, wrapMode);
            }
            return property;
        }
    }

    /// <summary>
    /// Extend any custom subpalettes from this, so they will be initialized correctly
    /// </summary>
    public abstract class DeStyleSubPalette
    {
        public abstract void Init();
    }

    public class BoxStyles
    {
        public GUIStyle def,
                        flat, flatAlpha10, flatAlpha25, // Flat with white background
                        sticky, stickyTop, // Without any margin (or only top margin)
                        outline01, outline02, outline03;

        internal void Init()
        {
            def = new GUIStyle(GUI.skin.box).Padding(6, 6, 6, 6);
            flat = new GUIStyle(def).Background(DeStylePalette.whiteSquare);
            flatAlpha10 = new GUIStyle(def).Background(DeStylePalette.whiteSquareAlpha10);
            flatAlpha25 = new GUIStyle(def).Background(DeStylePalette.whiteSquareAlpha25);
            sticky = new DeSkinStyle(new GUIStyle(flatAlpha25).MarginTop(-2).MarginBottom(0), new GUIStyle(flatAlpha10).MarginTop(-2).MarginBottom(0));
            stickyTop = new DeSkinStyle(new GUIStyle(flatAlpha25).MarginTop(-2).MarginBottom(7), new GUIStyle(flatAlpha10).MarginTop(-2).MarginBottom(7));
            outline01 = DeGUI.styles.box.flat.Clone().Background(DeStylePalette.squareBorderEmpty01);
            outline02 = outline01.Clone().Border(new RectOffset(5, 5, 5, 5)).Background(DeStylePalette.squareBorderEmpty02);
            outline03 = outline01.Clone().Border(new RectOffset(7, 7, 7, 7)).Background(DeStylePalette.squareBorderEmpty03);
        }
    }

    public class ButtonStyles
    {
        public GUIStyle def,
                        tool, toolL, toolS, toolIco,
                        toolFoldoutClosed, toolFoldoutClosedWLabel, toolFoldoutClosedWStretchedLabel,
                        toolFoldoutOpen, toolFoldoutOpenWLabel, toolFoldoutOpenWStretchedLabel,
                        toolLFoldoutClosed, toolLFoldoutClosedWLabel, toolLFoldoutClosedWStretchedLabel,
                        toolLFoldoutOpen, toolLFoldoutOpenWLabel, toolLFoldoutOpenWStretchedLabel,
                        bBlankBorder, bBlankBorderCompact;

        internal void Init()
        {
            def = new GUIStyle(GUI.skin.button);
            tool = new GUIStyle(EditorStyles.toolbarButton).ContentOffsetY(-1);
            toolL = new GUIStyle(EditorStyles.toolbarButton).Height(23).ContentOffsetY(0);
            toolS = new GUIStyle(EditorStyles.toolbarButton).Height(13).ContentOffsetY(0).Padding(0);
            toolIco = new GUIStyle(tool).StretchWidth(false).Width(22).ContentOffsetX(-1);
//            toolFoldoutClosed = new GUIStyle(GUI.skin.button) {
//                alignment = TextAnchor.UpperLeft,
//                active = { background = null },
//                fixedWidth = 14,
//                normal = { background = EditorStyles.foldout.normal.background },
//                border = EditorStyles.foldout.border,
//                padding = new RectOffset(14, 0, 0, 0)
//            }.MarginTop(2);
            toolFoldoutClosed = new GUIStyle(GUI.skin.button) {
                alignment = TextAnchor.MiddleLeft,
                active = { background = null },
                fixedWidth = 14,
                normal = { background = EditorStyles.foldout.normal.background },
                border = EditorStyles.foldout.border,
                padding = new RectOffset(14, 0, 0, 0),
                margin = new RectOffset(0, 3, 0, 0),
                overflow = new RectOffset(-2, 0, -2, 0),
                stretchHeight = true,
                contentOffset = new Vector2(2, -1)
            };
            toolFoldoutClosedWLabel = toolFoldoutClosed.Clone(9).Width(0).StretchWidth(false);
            toolFoldoutClosedWStretchedLabel = toolFoldoutClosedWLabel.Clone().StretchWidth();
            toolFoldoutOpen = new GUIStyle(toolFoldoutClosed) {
                normal = { background = EditorStyles.foldout.onNormal.background }
            };
            toolFoldoutOpenWLabel = new GUIStyle(toolFoldoutClosedWLabel) {
                normal = { background = EditorStyles.foldout.onNormal.background }
            };
            toolFoldoutOpenWStretchedLabel = toolFoldoutOpenWLabel.Clone().StretchWidth();
            // Large
            toolLFoldoutClosed = toolFoldoutClosed.Clone().OverflowTop(-4);
            toolLFoldoutClosedWLabel = toolFoldoutClosedWLabel.Clone().OverflowTop(-4);
            toolLFoldoutClosedWStretchedLabel = toolFoldoutClosedWStretchedLabel.Clone().OverflowTop(-4);
            toolLFoldoutOpen = toolFoldoutOpen.Clone().OverflowTop(-4);
            toolLFoldoutOpenWLabel = toolFoldoutOpenWLabel.Clone().OverflowTop(-4);
            toolLFoldoutOpenWStretchedLabel = toolFoldoutOpenWStretchedLabel.Clone().OverflowTop(-4);
            // Custom using squareBorder
            bBlankBorder = new GUIStyle(GUI.skin.button).Add(TextAnchor.MiddleCenter, Color.white).Background(DeStylePalette.squareBorderCurved)
                .Padding(0, 1, 1, 2).Border(new RectOffset(4, 4, 4, 4)).Overflow(-1, -1, 0, 0);
            bBlankBorderCompact = bBlankBorder.Clone().Padding(0, 1, 0, 0).ContentOffsetY(-1);
        }
    }

    public class LabelStyles
    {
        public GUIStyle bold, rightAligned,
                        wordwrap, wordwrapRichtText,
                        toolbar, toolbarRightAligned, toolbarL, toolbarS, toolbarBox;

        internal void Init()
        {
            bold = new GUIStyle(GUI.skin.label).Add(FontStyle.Bold);
            rightAligned = new GUIStyle(GUI.skin.label).Add(TextAnchor.MiddleRight);
            wordwrap = new GUIStyle(GUI.skin.label).Add(Format.WordWrap);
            wordwrapRichtText = wordwrap.Clone(Format.RichText);
            toolbar = new GUIStyle(GUI.skin.label).Add(9).ContentOffset(new Vector2(-2, 1));
            toolbarRightAligned = toolbar.Clone(TextAnchor.MiddleRight);
            toolbarL = new GUIStyle(toolbar).ContentOffsetY(3);
            toolbarS = new GUIStyle(toolbar).Add(8, FontStyle.Bold).ContentOffsetY(-2);
            toolbarBox = new GUIStyle(toolbar).ContentOffsetY(0);
        }
    }

    public class ToolbarStyles
    {
        public GUIStyle def,
                        large, small,
                        stickyTop,
                        box,
                        flat; // Flat with white background

        internal void Init()
        {
            def = new GUIStyle(EditorStyles.toolbar).Height(18).StretchWidth();
            large = new GUIStyle(def).Height(23);
            small = new GUIStyle(def).Height(13);
            stickyTop = new GUIStyle(def).MarginTop(0);
            box = new GUIStyle(GUI.skin.box).Height(20).StretchWidth().Padding(5, 6, 1, 0).Margin(0, 0, 0, 0);
            flat = new GUIStyle(GUI.skin.box).Height(18).StretchWidth().Padding(5, 6, 0, 0).Margin(0, 0, 0, 0).Background(DeStylePalette.whiteSquare);
        }
    }

    public class MiscStyles
    {
        public GUIStyle line; // Flat line with no margin

        internal void Init()
        {
            line = new GUIStyle(GUI.skin.box).Padding(0, 0, 0, 0).Margin(0, 0, 0, 0).Background(DeStylePalette.whiteSquare);
        }
    }
}