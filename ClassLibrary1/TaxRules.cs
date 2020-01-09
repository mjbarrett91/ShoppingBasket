﻿using ShoppingBasket.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket
{
    public static class TaxRules
    {
        public readonly static ITaxRule NoTax = new ItemSubTotalPercentageTaxRule();
    }
}
