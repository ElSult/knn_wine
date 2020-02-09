using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wine_API.Models;

namespace kNN
{
    class Normalize
    {
        public decimal fixedAcidity ;
        public decimal volatileAcidity;
        public decimal citricAcid;
        public decimal residualSugar;
        public decimal chlorides;
        public decimal freeSulfurDioxide;
        public decimal totalSulfurDioxide;
        public decimal density;
        public decimal pH;
        public decimal sulphates;
        public decimal alcohol;
        public decimal quality;

        public Normalize(winequalityRed wine, decimal MAXfixedAcidity , decimal MAXvolatileAcidity, decimal MAXcitricAcid, decimal MAXresidualSugar , decimal MAXchlorides, decimal MAXfreeSulfurDioxide , decimal MAXtotalSulfurDioxide, decimal MAXdensity , decimal MAXpH , decimal MAXsulphates , decimal MAXalcohol , decimal MAXquality )

        {
            fixedAcidity = Convert.ToDecimal( wine.fixed_acidity, CultureInfo.InvariantCulture) / (decimal)MAXfixedAcidity;
            volatileAcidity = Convert.ToDecimal(wine.volatile_acidity, CultureInfo.InvariantCulture) / (decimal)MAXvolatileAcidity;
            citricAcid = Convert.ToDecimal(wine.citric_acid, CultureInfo.InvariantCulture) / (decimal)MAXcitricAcid;
            residualSugar = Convert.ToDecimal(wine.residual_sugar, CultureInfo.InvariantCulture) / (decimal)MAXresidualSugar;
            chlorides = Convert.ToDecimal(wine.chlorides, CultureInfo.InvariantCulture) / (decimal)MAXchlorides;
            freeSulfurDioxide = Convert.ToDecimal(wine.free_sulfur_dioxide, CultureInfo.InvariantCulture) / (decimal)MAXfreeSulfurDioxide;
            totalSulfurDioxide = Convert.ToDecimal(wine.total_sulfur_dioxide, CultureInfo.InvariantCulture) / (decimal)MAXtotalSulfurDioxide;
            density = Convert.ToDecimal(wine.density, CultureInfo.InvariantCulture) / (decimal)MAXdensity;
            pH = Convert.ToDecimal(wine.pH, CultureInfo.InvariantCulture) / (decimal)MAXpH;
            sulphates = Convert.ToDecimal(wine.sulphates, CultureInfo.InvariantCulture) / (decimal)MAXsulphates;
            alcohol = Convert.ToDecimal(wine.alcohol, CultureInfo.InvariantCulture) / (decimal)MAXalcohol;
            quality = Convert.ToDecimal(wine.quality, CultureInfo.InvariantCulture) / (decimal)MAXquality;
        }
    }
}
