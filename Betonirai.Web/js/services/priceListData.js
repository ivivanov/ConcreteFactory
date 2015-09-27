'use strict';

ngApp.factory('priceListData', function () {
    var data =
        {
            pompi: {
                title: "Бетон-помпи (до 30 м³, 1/2 м/см)",
                items: [
                    {
                        number: 1,
                        name: "Бетон-помпа 28м. - до 30 кубика"
                    },
                    {
                        number: 1,
                        name: "Бетон-помпа 36м. - до 30 кубика"
                    },
                    {
                        number: 1,
                        name: "Бетон-помпа 42м. - до 30 кубика"
                    },
                    {
                        number: 1,
                        name: "Бетон-помпа 53м. - до 30 кубика"
                    }
                ]
            },
            zamazki: {
                title: "Пясъчно-циментови замаски",
                items: [
                  {
                      number: 1,
                      name: "Замазка М 15"
                  },
                  {
                      number: 2,
                      name: "Замазка М 20"
                  },
                  {
                      number: 3,
                      name: "Замазка М 30"
                  },
                  {
                      number: 4,
                      name: "Варов разтвор"
                  }
                ]
            },
            beton: {
                title: "Видове бетон",
                items: [
                  {
                      number: 1,
                      name: "Бетон В 10 (С8/10)"
                  },
                  {
                      number: 2,
                      name: "Бетон В 12.5 (С10/12)"
                  },
                  {
                      number: 3,
                      name: "Бетон В 15 (С12/15)"
                  },
                  {
                      number: 4,
                      name: "Бетон В 20 (С16/20)"
                  },
                  {
                      number: 5,
                      name: "Бетон В 25 (С20/25)"
                  },
                  {
                      number: 6,
                      name: "Бетон В 30 (С25/30)"
                  },
                  {
                      number: 7,
                      name: "Бетон В 35 (С30/35)"
                  },
                  {
                      number: 8,
                      name: "Бетон В 40 (С32/40)"
                  },
                  {
                      number: 9,
                      name: "Бетон В 45 (С35/45)"
                  },
                  {
                      number: 10,
                      name: "Бетон В 50 (С40/50)"
                  }
                ]
            },
            dobavki: {
                title: "Добавки (за 1 м³ бетон)",
                items: [
                  {
                      number: 1,
                      name: "Зимно бетониране до -5°C"
                  },
                  {
                      number: 2,
                      name: "Зимно бетониране до -10°C"
                  },
                  {
                      number: 3,
                      name: "Ускорено декофриране - на 7-ми ден"
                  },
                  {
                      number: 4,
                      name: "Ускорено декофриране - на 14-ти ден"
                  },
                  {
                      number: 5,
                      name: "Водоплътни бетони - W 0.4"
                  },
                  {
                      number: 6,
                      name: "Водоплътни бетони - W 0.6"
                  },
                  {
                      number: 7,
                      name: "Водоплътни бетони - W 0.8"
                  },
                  {
                      number: 8,
                      name: "Водоплътни бетони - W 1.0"
                  }
                ]
            }
        };

    return {
        getPriceList: function (id) {
            return data[id];
        }
    }
})