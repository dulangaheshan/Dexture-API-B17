from sqlalchemy import text
from flask import Flask
from flask import request
from flask import jsonify

import sqlalchemy as sa
import pandas as pd
from sklearn.model_selection import train_test_split
from flask_cors import CORS

from sklearn.linear_model import LinearRegression
# from sqlalchemy import *

app = Flask(__name__)
cors = CORS(app, resources={r"/*": {"origins": "*"}})
cors = CORS(app, resources={r"/hello/*": {"origins": "*"}})
import urllib
params = urllib.parse.quote_plus('DRIVER={SQL Server};SERVER=DESKTOP-5NUF3HJ;DATABASE=DextureDB;Trusted_Connection=yes;')
app.config['SQLALCHEMY_DATABASE_URI'] = "mssql+pyodbc:///?odbc_connect=%s" % params
engine = sa.create_engine("mssql+pyodbc:///?odbc_connect={}".format(params))


HarvestName = [] #1
SellingQuantities = [] #2
AllQuantities = [] #3
salesQuantites = []
years = [] #4

@app.route("/")
def index():
  allQuantitygraphData = []
  allData =  connect()
  for i in range(0,len(allData[0])):
    data1 = {'y':int(allData[1][i]),'label':allData[0][i]}
    data2 = {'y':int(allData[2][i]),'label':allData[0][i]}
    allQuantitygraphData.append(data1)
    salesQuantites.append(data2)
  return jsonify([allQuantitygraphData,salesQuantites])

@app.route("/hello", methods=['GET', 'POST'])   
def hello():
  year = request.get_json(force = True)
  print("sdsd")
  print(year)
  connect();
    
  HarvestDF = pd.DataFrame(
  {'HarvestName': HarvestName,
     'SellingQuantities': SellingQuantities,
     'AllQuantities': AllQuantities,
     'Years':years
  })
  # print(result)
  predit = prediction(HarvestDF,year)
  return jsonify(predit.tolist())


def prediction(df,year):
  print(df)
  X_train = df[['Years']]
  y_train = df[['SellingQuantities','AllQuantities']]
  lm = LinearRegression()
  lm.fit(X_train,y_train)
  predictions = lm.predict([[int(year)]])
  print(predictions)
  return predictions

def connect():
  sql = sa.text('select * from Harvests')
  result = engine.engine.execute(sql).fetchall()
  # print(result)
  del HarvestName [:]
  del SellingQuantities [:]
  del AllQuantities [:]
  del years [:]
  for row in result:
    harvestData = list(row)
    HarvestName.append(harvestData[1])
    SellingQuantities.append(harvestData[2])
    AllQuantities.append(harvestData[3])
    years.append(harvestData[4])
    
  return [years,AllQuantities,SellingQuantities]




@app.route("/members")
def members():
    return "Members"



if __name__ == "__main__":
    app.run(debug=True)