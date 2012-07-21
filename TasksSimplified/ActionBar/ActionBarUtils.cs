/*
 * Copyright (C) 2012 James Montemagno <http://www.montemagno.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using Android.App;
using TasksSimplified.Helpers;

namespace TasksSimplified.ActionBar
{
    public class ActionBarUtils
    {
        /// <summary>
        /// determins if the action should be added and fits
        /// based on stats from http://developer.android.com/design/patterns/actionbar.html
        /// </summary>
        /// <param name="activity">Current Activity, needed for orientation and density</param>
        /// <param name="currentNumber">current position of the action</param>
        /// <param name="hasMenuButton"></param>
        /// <param name="actionType"></param>
        /// <returns>If it will fit :)</returns>
        public static bool ActionFits(Activity activity, int currentNumber, bool hasMenuButton, ActionType actionType)
        {
            if (actionType == ActionType.Always)
                return true;

            if (actionType == ActionType.Never)
                return false;

            if (activity == null)
                return true;

            var density = activity.Resources.DisplayMetrics.Density;
            if (density == 0)
                return true;
            density = (int)(activity.Resources.DisplayMetrics.WidthPixels / density);//calculator DP of width.


            var max = 5;
            if(density < 360)
            {
                max = 2;
            }
            else if(density < 500)
            {
                max = 3;
            }
            else if(density < 598)//should be 600, but Galaxy nexus returns 598
            {
                max = 4;
            }

            if (!hasMenuButton)
                max--;

            return currentNumber < max;
        }

        /// <summary>
        /// A LinkedList that holds a list of Action.
        /// </summary>
        public class ActionList : LinkedList<ActionBarAction>
        {
        }

        public static void SetActionBarTheme(ActionBar actionBar, int theme)
        {
            switch (theme)
            {
                case 0: //light gray
                    actionBar.SeparatorColorRaw = Resource.Color.actionbar_separator_lightgray;
                    actionBar.TitleColorRaw = Resource.Color.actionbar_title_lightgray;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.actionbar_btn_lightgray;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.actionbar_background_lightgray;
                    break;
                case 1: //dark gray
                    actionBar.SeparatorColorRaw = Resource.Color.actionbar_separator_darkgray;
                    actionBar.TitleColorRaw = Resource.Color.actionbar_title_darkgray;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.actionbar_btn;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.actionbar_background;
                    break;
                case 2://blue
                    actionBar.SeparatorColorRaw = Resource.Color.actionbar_separator_blue;
                    actionBar.TitleColorRaw = Resource.Color.actionbar_title_blue;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.actionbar_btn_blue;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.actionbar_background_blue;
                    break;
                case 3: //black
                    actionBar.SeparatorColorRaw = Resource.Color.actionbar_separator_black;
                    actionBar.TitleColorRaw = Resource.Color.actionbar_title_black;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.actionbar_btn_black;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.actionbar_background_black;
                    break;
            }
        }

        public static void SetBottomActionBarTheme(ActionBar actionBar, int theme)
        {
            switch (theme)
            {
                case 0: //light gray
                    actionBar.SeparatorColorRaw = Resource.Color.bottomactionbar_separator;
                    actionBar.TitleColorRaw = Resource.Color.actionbar_title_lightgray;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.bottomactionbar_btn_lightgray;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.bottomactionbar_background_lightgray;
                    break;
                case 1: //dark gray
                    actionBar.SeparatorColorRaw = Resource.Color.bottomactionbar_separator;
                    actionBar.TitleColorRaw = Resource.Color.actionbar_title_darkgray;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.bottomactionbar_btn;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.bottomactionbar_background;
                    break;
                case 2://blue
                    actionBar.SeparatorColorRaw = Resource.Color.bottomactionbar_separator;
                    actionBar.TitleColorRaw = Resource.Color.actionbar_title_blue;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.bottomactionbar_btn_blue;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.bottomactionbar_background_blue;
                    break;
                case 3: //black
                    actionBar.SeparatorColorRaw = Resource.Color.bottomactionbar_separator;
                    actionBar.TitleColorRaw = Settings.DarkTheme ? Resource.Color.actionbar_title_black : Resource.Color.actionbar_title;
                    actionBar.ItemBackgroundDrawableRaw = Resource.Drawable.bottomactionbar_btn_black;
                    actionBar.BackgroundDrawableRaw = Resource.Drawable.bottomactionbar_background_black;
                    break;
            }
        }
    }
}