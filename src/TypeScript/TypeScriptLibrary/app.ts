import { read } from "fs";
import { ICategoryArrow } from "./Library/Interfaces/ICategoryArrow";
import { ICategoryObject } from "./Library/Interfaces/ICategoryObject";
import { DataLink } from "./Library/Measurements/DataLink";
import { Performer } from "./Library/Performer";
import { OrbitAct } from "./OrbitAct";
import { Orbital } from "./src/Orbital";
import * as readline from 'readline';
actT();

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question('Is this example useful? [y/n] ', (answer) => {
    switch (answer.toLowerCase()) {
        case 'y':
            console.log('Super!');
            break;
        case 'n':
            console.log('Sorry! :(');
            break;
        default:
            console.log('Invalid answer!');
    }
    rl.close();
});
function load() {
    try {

        let orb = new Orbital();
        let objs = orb.getObjects();
        let p = new Performer();
        var al = p.select<ICategoryObject>(objs, "IAlias");
        var ln = p.select<ICategoryArrow>(objs, "DataLink");
        var dl = p.select<DataLink>(objs, "ICategoryArrow");
        let i = 0;
    }
    catch (e: any) {
        let ii = 0;
        ii++;

    }
}



function actT() {
    try {
        var o = new OrbitAct();
        o.test();
    }
    catch (e: any)
    {
        var i = 0;
    }
}

