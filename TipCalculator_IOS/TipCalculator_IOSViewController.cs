using System;
using System.Drawing;

using Foundation;
using UIKit;

namespace TipCalculator_IOS
{
	public partial class TipCalculator_IOSViewController : UIViewController
	{
		public TipCalculator_IOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			AmountTextBox.EditingDidEndOnExit += (object sender, EventArgs e) => ((UITextField)sender).ResignFirstResponder ();

			((UIControl)View).TouchDown += (sender, e) => AmountTextBox.ResignFirstResponder ();

			TaxPercentageTextBox.EditingDidEndOnExit += (object sender, EventArgs e) => ((UITextField)sender).ResignFirstResponder ();

			((UIControl)View).TouchDown += (sender, e) => TaxPercentageTextBox.ResignFirstResponder ();

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		/// <summary>
		/// This method changes the tax percentage label when the slider is adjusted.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void ServiceSlider_ValueChanged (UISlider sender)
		{
			int tipPercent = (int)sender.Value;
			TipPercentageLabel.Text = tipPercent.ToString();

			WhenValuesChange();
		}

		/// <summary>
		/// This method hides all tax controls based on the tax switch and action sheet response.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void TaxSwitch_ValueChanged (UISwitch sender)
		{
			var setting = sender.On;

			if (setting)
			{
				var taxonActionSheet = new UIActionSheet ("Turning taxes on.  Is that OK?");
				taxonActionSheet.AddButton ("Yes");
				taxonActionSheet.DestructiveButtonIndex = 0;
				taxonActionSheet.AddButton ("Cancel");
				taxonActionSheet.CancelButtonIndex = 1;
				taxonActionSheet.Clicked += delegate(object a, UIButtonEventArgs b) {
					if (b.ButtonIndex == 0)
					{
						ManipulateControls (false);
						TaxSwitch.On = true;

					} else {
						ManipulateControls (true);
						TaxSwitch.On = false;
					}
					WhenValuesChange();
				};

				taxonActionSheet.ShowInView (View);
			} else {				
				var taxoffActionSheet = new UIActionSheet ("Turning taxes off.  Is that OK?");
				taxoffActionSheet.AddButton ("Yes");
				taxoffActionSheet.DestructiveButtonIndex = 0;
				taxoffActionSheet.AddButton ("Cancel");
				taxoffActionSheet.CancelButtonIndex = 1;
				taxoffActionSheet.Clicked += delegate(object a, UIButtonEventArgs b) {
					if (b.ButtonIndex == 0)
					{
						ManipulateControls (true);
						TaxSwitch.On = false;
					} else {
						ManipulateControls (false);
						TaxSwitch.On = true;
					}
					WhenValuesChange();
				};

				taxoffActionSheet.ShowInView (View);
			}
				
		}

		/// <summary>
		/// This method is a helper routine to hide tax buttons.
		/// </summary>
		/// <param name="willHide">If set to <c>true</c> will hide.</param>
		public void ManipulateControls (bool willHide)
		{
			if (willHide) {
				TaxLabel.Hidden = true;
				TaxPercentageTextBox.Hidden = true;
				TaxAmountLabel.Hidden = true;
				TaxPercentageTextBox.Text = "";
				TaxAmountLabel.Text = "";
			} else {
				TaxLabel.Hidden = false;
				TaxPercentageTextBox.Hidden = false;
				TaxAmountLabel.Hidden = false;
			}
		}

		/// <summary>
		/// This method calculates the tip when focus is moved from AmountTextBox
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void AmountTextBox_Changed (UITextField sender)
		{
			WhenValuesChange();

		}

		/// <summary>
		/// This method calculates the tax when focus is moved from TaxPercentageTextBox
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void TaxPercentageTextBox_Changed (UITextField sender)
		{
			WhenValuesChange();
		}

		/// <summary>
		/// This is a generic method to redo all the calculations when controls have activity.
		/// </summary>
		public void WhenValuesChange ()
		{
			var c = new ComputeIt();
			decimal amount = 0;
			decimal percentage = 0;
			decimal tip = 0;
			decimal tax = 0;
			decimal total = 0;

			// Tip Calculation
			amount = AmountTextBox.Text.Trim ().Length == 0 ? 0 : Convert.ToDecimal (AmountTextBox.Text);
			percentage = TipPercentageLabel.Text.Trim ().Length == 0 ? 0 : Convert.ToDecimal (TipPercentageLabel.Text);

			tip = c.ComputeTip(percentage, amount);

			TipAmountLabel.Text = string.Format("{0:C}", tip);

			// Tax Calculation
			percentage = TaxPercentageTextBox.Text.Trim ().Length == 0 ? 0 : Convert.ToDecimal (TaxPercentageTextBox.Text);

			tax = c.ComputeTax (percentage, amount);

			TaxAmountLabel.Text = string.Format ("{0:C}", tax);

			// Total Calculation
			total = c.ComputeTotal(amount, tip, tax);

			TotalAmountLabel.Text = string.Format ("{0:C}", total);

		}

		#endregion
	}
}

