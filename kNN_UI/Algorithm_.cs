using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wine_API.Models;

namespace kNN
{
    class Algorithm_
    {
        int kNN;
        int totalTrainset;
        List<winequalityRed> wineSet;
        List<winequalityRed> trainset;

        Distance [] distances;

        decimal MAXfixedAcidity;
        decimal MAXvolatileAcidity;
        decimal MAXcitricAcid;
        decimal MAXresidualSugar;
        decimal MAXchlorides;
        decimal MAXfreeSulfurDioxide;
        decimal MAXtotalSulfurDioxide;
        decimal MAXdensity;
        decimal MAXpH;
        decimal MAXsulphates;
        decimal MAXalcohol;
        decimal MAXquality;


        public Algorithm_(  int k, List <winequalityRed> train, List <winequalityRed> wineSet)
        {
            this.kNN = k;//k neighbor
           
            this.trainset = train;//trainset
            this.wineSet =  wineSet;//customer
            this.totalTrainset = train.Count;//total of wine

            distances = new Distance [this.totalTrainset];

            //get max value of each column need to normalize
            MaxinumValue maximum = new MaxinumValue(train);
            maximum.findAllMax();

            MAXfixedAcidity = maximum.getFixedAcidity();
            MAXvolatileAcidity = maximum.getVolatileAcidity();
            MAXcitricAcid = maximum.getCitricAcid();
            MAXresidualSugar = maximum.getResidualSugar();
            MAXchlorides = maximum.getChlorides();
            MAXfreeSulfurDioxide = maximum.getFreeSulfurDioxide();
            MAXtotalSulfurDioxide = maximum.getTotalSulfurDioxide();
            MAXdensity = maximum.getDensity();
            MAXpH = maximum.getPH();
            MAXsulphates = maximum.getSulphates();
            MAXalcohol = maximum.getAlcohol();
            MAXquality = maximum.getQuality();

        }

        public void setResponse(winequalityRed wine )
        {
            //normalize cus
            Normalize nWine = new Normalize(wine,MAXfixedAcidity,MAXvolatileAcidity,MAXcitricAcid,MAXresidualSugar,MAXchlorides,MAXfreeSulfurDioxide,MAXtotalSulfurDioxide,MAXdensity,MAXpH,MAXsulphates,MAXalcohol,MAXquality
                );


            //calculate all distances
            for (int i = 0; i < this.totalTrainset; i++)
            {
                distances[i] = new Distance();
                distances[i].distance = 0;
                distances[i].index = i;

                //normalize element
                Normalize tmp = new Normalize(this.trainset[i], MAXfixedAcidity, MAXvolatileAcidity, MAXcitricAcid, MAXresidualSugar, MAXchlorides, MAXfreeSulfurDioxide, MAXtotalSulfurDioxide, MAXdensity, MAXpH, MAXsulphates, MAXalcohol, MAXquality);


                //distance between two fixedAcidity normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal( nWine.fixedAcidity, CultureInfo.InvariantCulture) , Convert.ToDecimal(tmp.fixedAcidity, CultureInfo.InvariantCulture));


                //distance between two volatileAcidity normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.volatileAcidity, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.volatileAcidity, CultureInfo.InvariantCulture));


                //distance between two citricAcid normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.citricAcid, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.citricAcid, CultureInfo.InvariantCulture));

                //distance between two residualSugar normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.residualSugar, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.residualSugar, CultureInfo.InvariantCulture));

                //distance between two chlorides normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.chlorides, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.chlorides, CultureInfo.InvariantCulture));

                //distance between two freeSulfurDioxide normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.freeSulfurDioxide, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.freeSulfurDioxide, CultureInfo.InvariantCulture));

                //distance between two totalSulfurDioxide normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.totalSulfurDioxide, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.totalSulfurDioxide, CultureInfo.InvariantCulture));

                //distance between two density normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.density, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.density, CultureInfo.InvariantCulture));

                //distance between two pH normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.pH, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.pH, CultureInfo.InvariantCulture));

                //distance between two sulphates normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.sulphates, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.sulphates, CultureInfo.InvariantCulture));

                //distance between two alcohol normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.alcohol, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.alcohol, CultureInfo.InvariantCulture));

                //distance between two quality normalized
                distances[i].distance = distances[i].distance + getDistance
                    (Convert.ToDecimal(nWine.quality, CultureInfo.InvariantCulture), Convert.ToDecimal(tmp.quality, CultureInfo.InvariantCulture));
            }// end loop


            //sort
            for (int i = 0; i < totalTrainset - 1; i++)
            {
                for (int j = i + 1; j < totalTrainset; j++)
                {
                    if (distances[i].distance > distances[j].distance)
                    {
                        Distance tmp = distances[i];
                        distances[i] = distances[j];
                        distances[j] = tmp;
                    }//swap
                }//end j loop

            }//end i loop



            //select k nearest neighbor
            int yesCount = 0;
            int noCount = 0;

            decimal sumQuality = 0;
            for (int i = 0; i < kNN; i++)
            {
                winequalityRed tmp = trainset[ distances[i].index ];
                sumQuality +=Convert.ToDecimal( tmp.quality, CultureInfo.InvariantCulture);
                //if (tmp.getResponse() == 0)
                //{
                //    noCount = noCount + 1;
                //}
                //else if ( tmp.getResponse() == 1 )
                //{
                //    yesCount = yesCount + 1;
                //}
            }



            //set response value for unknown customer
            //if (yesCount > noCount)
            //{
            //    cus.setResponse(1);
            //}
            //else if (yesCount < noCount)
            //{
            //    cus.setResponse(0);
            //}
            wine.quality = ((int)Math.Round(sumQuality / (decimal)kNN)).ToString();



        }

        public decimal getDistance(decimal a, decimal b)
        {
            return (a - b) * (a - b);
        }

        public void runkNN()
        {
            for (int i = 0; i < this.wineSet.Count; i++)
            {
                setResponse(this.wineSet[i]);
            }
        }

        public List<winequalityRed> getWineList()
        {
            return this.wineSet;
        }


    }
}
