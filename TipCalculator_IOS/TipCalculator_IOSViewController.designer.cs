// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TipCalculator_IOS
{
	[Register ("TipCalculator_IOSViewController")]
	partial class TipCalculator_IOSViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AmountTextBox { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISlider ServiceSlider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TaxAmountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TaxLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField TaxPercentageTextBox { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch TaxSwitch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TipAmountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIControl TipCalculatorView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TipPercentageLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TotalAmountLabel { get; set; }

		[Action ("AmountTextBox_Changed:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void AmountTextBox_Changed (UITextField sender);

		[Action ("ServiceSlider_ValueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ServiceSlider_ValueChanged (UISlider sender);

		[Action ("TaxPercentageTextBox_Changed:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void TaxPercentageTextBox_Changed (UITextField sender);

		[Action ("TaxSwitch_ValueChanged:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void TaxSwitch_ValueChanged (UISwitch sender);

		void ReleaseDesignerOutlets ()
		{
			if (AmountTextBox != null) {
				AmountTextBox.Dispose ();
				AmountTextBox = null;
			}
			if (ServiceSlider != null) {
				ServiceSlider.Dispose ();
				ServiceSlider = null;
			}
			if (TaxAmountLabel != null) {
				TaxAmountLabel.Dispose ();
				TaxAmountLabel = null;
			}
			if (TaxLabel != null) {
				TaxLabel.Dispose ();
				TaxLabel = null;
			}
			if (TaxPercentageTextBox != null) {
				TaxPercentageTextBox.Dispose ();
				TaxPercentageTextBox = null;
			}
			if (TaxSwitch != null) {
				TaxSwitch.Dispose ();
				TaxSwitch = null;
			}
			if (TipAmountLabel != null) {
				TipAmountLabel.Dispose ();
				TipAmountLabel = null;
			}
			if (TipCalculatorView != null) {
				TipCalculatorView.Dispose ();
				TipCalculatorView = null;
			}
			if (TipPercentageLabel != null) {
				TipPercentageLabel.Dispose ();
				TipPercentageLabel = null;
			}
			if (TotalAmountLabel != null) {
				TotalAmountLabel.Dispose ();
				TotalAmountLabel = null;
			}
		}
	}
}
