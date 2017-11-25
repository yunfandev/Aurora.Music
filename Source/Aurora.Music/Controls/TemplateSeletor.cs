﻿using Aurora.Music.Core.Models;
using Aurora.Music.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Aurora.Music.Controls
{
    class HomePageTemplateSeletor : DataTemplateSelector
    {
        public DataTemplate AlbumTemplate { get; set; }
        public DataTemplate SongTemplate { get; set; }
        public DataTemplate PlayListTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is GenericMusicItemViewModel m)
            {
                switch (m.InnerType)
                {
                    case MediaType.Song:
                        return SongTemplate;
                    case MediaType.Album:
                        return AlbumTemplate;
                    case MediaType.PlayList:
                        return PlayListTemplate;
                    default:
                        return SongTemplate;
                }
            }
            return SongTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is GenericMusicItemViewModel m)
            {
                switch (m.InnerType)
                {
                    case MediaType.Song:
                        return SongTemplate;
                    case MediaType.Album:
                        return AlbumTemplate;
                    case MediaType.PlayList:
                        return PlayListTemplate;
                    default:
                        return SongTemplate;
                }
            }
            return SongTemplate;
        }
    }

    class SongListTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate OddTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is SongViewModel s)
            {
                if (s.Index % 2 == 0)
                {
                    return EvenTemplate;
                }
                else
                {
                    return OddTemplate;
                }
            }
            return EvenTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var listview = ItemsControl.ItemsControlFromItemContainer(container);
            var index = listview.IndexFromContainer(container);
            if (index % 2 == 0)
            {
                return EvenTemplate;
            }
            else
            {
                return OddTemplate;
            }
        }
    }
}