using System;

namespace TipCalculator_IOS
{
	public class ComputeIt
	{
		/// <summary>
		/// Computes the tip.
		/// </summary>
		/// <returns>The tip.</returns>
		/// <param name="tipPercent">Tip percent.</param>
		/// <param name="mealAmount">Meal amount.</param>
		public decimal ComputeTip (decimal tipPercent, decimal mealAmount)
		{
			decimal tip = mealAmount * ( tipPercent / 100);

			return tip;	
		}

		/// <summary>
		/// Computes the tax.
		/// </summary>
		/// <returns>The tax.</returns>
		/// <param name="taxPercent">Tax percent.</param>
		/// <param name="mealAmount">Meal amount.</param>
		public decimal ComputeTax (decimal taxPercent, decimal mealAmount)
		{
			decimal tax = mealAmount * (taxPercent / 100);

			return tax;
		}

		/// <summary>
		/// Computes the total.
		/// </summary>
		/// <returns>The total.</returns>
		/// <param name="mealAmount">Meal amount.</param>
		/// <param name="tip">Tip.</param>
		/// <param name="tax">Tax.</param>
		public decimal ComputeTotal(decimal mealAmount, decimal tip, decimal tax)
		{
			decimal total = mealAmount + tip + tax;

			return total;
		}
	}
}

