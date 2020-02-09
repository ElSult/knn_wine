using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wine_API.Models;

namespace kNN
{
    class MaxinumValue
    {
        decimal MAXfixedAcidity = 0;
        decimal MAXvolatileAcidity = 0;
        decimal MAXcitricAcid = 0;
        decimal MAXresidualSugar = 0;
        decimal MAXchlorides = 0;
        decimal MAXfreeSulfurDioxide = 0;
        decimal MAXtotalSulfurDioxide = 0;
        decimal MAXdensity = 0;
        decimal MAXpH = 0;
        decimal MAXsulphates = 0;
        decimal MAXalcohol = 0;
        decimal MAXquality = 0;


        int maxAge = 0;
        int maxIncome = 0;
        int maxnumCard = 0;

        List<winequalityRed> lWine = new List<winequalityRed>();

        public MaxinumValue(  List <winequalityRed> lw )
        {
            this.lWine = lw;
        }

        public void findAllMax()
        {
            for (int i = 0; i < this.lWine.Count; i++)
            {
                //find MAXfixedAcidity
                if (Convert.ToDecimal( this.lWine[i].fixed_acidity) > MAXfixedAcidity)
                {
                    MAXfixedAcidity = Convert.ToDecimal(this.lWine[i].fixed_acidity, CultureInfo.InvariantCulture);
                }
                //find MAXvolatileAcidity
                if (Convert.ToDecimal(this.lWine[i].volatile_acidity) > MAXvolatileAcidity)
                {
                    MAXvolatileAcidity = Convert.ToDecimal(this.lWine[i].volatile_acidity, CultureInfo.InvariantCulture);
                }
                //find MAXcitricAcid
                if (Convert.ToDecimal(this.lWine[i].citric_acid) > MAXcitricAcid)
                {
                    MAXcitricAcid = Convert.ToDecimal(this.lWine[i].citric_acid, CultureInfo.InvariantCulture);
                }
                //find MAXresidualSugar
                if (Convert.ToDecimal(this.lWine[i].residual_sugar) > MAXresidualSugar)
                {
                    MAXresidualSugar = Convert.ToDecimal(this.lWine[i].residual_sugar, CultureInfo.InvariantCulture);
                }
                //find MAXchlorides
                if (Convert.ToDecimal(this.lWine[i].chlorides) > MAXchlorides)
                {
                    MAXchlorides = Convert.ToDecimal(this.lWine[i].chlorides, CultureInfo.InvariantCulture);
                }
                //find MAXfreeSulfurDioxide
                if (Convert.ToDecimal(this.lWine[i].free_sulfur_dioxide) > MAXfreeSulfurDioxide)
                {
                    MAXfreeSulfurDioxide = Convert.ToDecimal(this.lWine[i].free_sulfur_dioxide, CultureInfo.InvariantCulture);
                }
                //find MAXtotalSulfurDioxide
                if (Convert.ToDecimal(this.lWine[i].total_sulfur_dioxide) > MAXtotalSulfurDioxide)
                {
                    MAXtotalSulfurDioxide = Convert.ToDecimal(this.lWine[i].total_sulfur_dioxide, CultureInfo.InvariantCulture);
                }
                //find MAXdensity
                if (Convert.ToDecimal(this.lWine[i].density) > MAXdensity)
                {
                    MAXdensity = Convert.ToDecimal(this.lWine[i].density, CultureInfo.InvariantCulture);
                }
                //find MAXpH
                if (Convert.ToDecimal(this.lWine[i].pH) > MAXpH)
                {
                    MAXpH = Convert.ToDecimal(this.lWine[i].pH, CultureInfo.InvariantCulture);
                }
                //find MAXsulphates
                if (Convert.ToDecimal(this.lWine[i].sulphates) > MAXsulphates)
                {
                    MAXsulphates = Convert.ToDecimal(this.lWine[i].sulphates, CultureInfo.InvariantCulture);
                }
                //find MAXalcohol
                if (Convert.ToDecimal(this.lWine[i].alcohol) > MAXalcohol)
                {
                    MAXalcohol = Convert.ToDecimal(this.lWine[i].alcohol, CultureInfo.InvariantCulture);
                }

                //find MAXquality
                if (Convert.ToDecimal(this.lWine[i].quality) > MAXquality)
                {
                    MAXquality = Convert.ToDecimal(this.lWine[i].quality, CultureInfo.InvariantCulture);
                }


                ////find maxIncome
                //if (this.lCustomer[i].getIncoming() > maxIncome)
                //{
                //    maxIncome = this.lCustomer[i].getIncoming();
                //}


                ////find maxNumcard
                //if (this.lCustomer[i].getNumcard() > maxnumCard)
                //{
                //    maxnumCard = this.lCustomer[i].getNumcard();
                //}

            }//end loop
        }


        //public int getMaxAge()
        //{
        //    return this.maxAge;
        //}
        public decimal getFixedAcidity()
        {
            return this.MAXfixedAcidity;
        }
        public decimal getVolatileAcidity()
        {
            return this.MAXvolatileAcidity;
        }
        public decimal getCitricAcid()
        {
            return this.MAXcitricAcid;
        }
        public decimal getResidualSugar()
        {
            return this.MAXresidualSugar;
        }
        public decimal getChlorides()
        {
            return this.MAXchlorides;
        }
        public decimal getFreeSulfurDioxide()
        {
            return this.MAXfreeSulfurDioxide;
        }
        public decimal getTotalSulfurDioxide()
        {
            return this.MAXtotalSulfurDioxide;
        }
        public decimal getDensity()
        {
            return this.MAXdensity;
        }
        public decimal getPH()
        {
            return this.MAXpH;
        }
        public decimal getSulphates()
        {
            return this.MAXsulphates;
        }
        public decimal getAlcohol()
        {
            return this.MAXalcohol;
        }
        public decimal getQuality()
        {
            return this.MAXquality;
        }


        //public int getMaxIncome()
        //{
        //    return this.maxIncome;
        //}

        //public int getMaxNumCard()
        //{
        //    return this.maxnumCard;
        //}
    }
}
