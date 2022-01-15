using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleApp.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SampleApp.Controls;
using AndroidX.CoordinatorLayout.Widget;
using Com.Nightonke.Boommenu;
using Com.Nightonke.Boommenu.Piece;
using Com.Nightonke.Boommenu.BoomButtons;

[assembly: ExportRenderer(typeof(BoomMenuView), typeof(BoomMenuViewRenderer))]
namespace SampleApp.Droid.Renderers
{
    public class BoomMenuViewRenderer : ViewRenderer<BoomMenuView,CoordinatorLayout>
    {
        public BoomMenuViewRenderer(Context context) : base(context)
        {

        }

        private CoordinatorLayout mCoordinatorLayout;

        protected override void OnElementChanged(ElementChangedEventArgs<BoomMenuView> e)
        {
            base.OnElementChanged(e);

            var layout = Inflate(Context, Resource.Layout.boommenulayout, null);
            if (mCoordinatorLayout == null)
            {
                mCoordinatorLayout = layout as CoordinatorLayout;
            }

            var boomBtn = mCoordinatorLayout.FindViewById<BoomMenuButton>(Resource.Id.bmb);

            boomBtn.ButtonEnum = ButtonEnum.SimpleCircle;
            boomBtn.PiecePlaceEnum = PiecePlaceEnum.Dot91;
            boomBtn.ButtonPlaceEnum = ButtonPlaceEnum.Sc91;

            var btnNum = boomBtn.ButtonPlaceEnum.ButtonNumber();

            for (int i = 0; i < btnNum; i++)
            {
                var builder = new SimpleCircleButton.Builder();
                builder.NormalImageRes(Resource.Drawable.bee);
                builder.Listener(new Clicked(Context));
                boomBtn.AddBuilder(builder);
            }

            SetNativeControl(mCoordinatorLayout);
        }
    }

    public class Clicked : Java.Lang.Object, IOnBMClickListener
    {
        public Clicked(Context context)
        {
            mContext = context;
        }

        private Context mContext;

        public void OnBoomButtonClick(int p0)
        {
            Toast.MakeText(mContext, $"你点击了第{p0}个按钮", ToastLength.Short).Show();
        }
    }
}