import { Actor } from './src/Tests/Actor/Actor';

let a = new Actor()

var mtl = "c:\\AUsers\\1MySoft\\CSharp\\src\\Web\\reactprojectgenerated\\static\\models\\pLANE\\master.mtl"
var caravan = "c:\\AUsers\\1MySoft\\CSharp\\src\\Web\\reactprojectgenerated\\static\\models\\pLANE\\Cessna_208_Caravan.obj"

//a.loadObj(caravan)
//a.readTest(mtl)
//a.actAirplane()

//await a.actDonchianLoad();

//a.readTest000m()
//a.actPI()
//a.testDate();

//a.actTime();

//a.actOrbitCalculation(true);// 1770457504

//a.actDensity();

//a.actODEFeedback();

//a.actRecursiveFeedback();

//a.actFeedbackFormula();
//a.actRecursiveFeedbackSimplw();

a.testRecursive();

//a.getTradingFromFile("C:\\0\\0\\1.json")

async function test() {
    await a.actDonchian()
}

//test();

a.finish(undefined);

