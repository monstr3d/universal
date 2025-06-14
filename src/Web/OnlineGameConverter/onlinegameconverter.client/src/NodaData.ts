import { http } from './http';

export interface Note {
  Name: string;
  Description: string;
}

export interface ExtededNote {
  Name: string;
  Description: string;
  DateTime: string;
}

export const getExtendedNote = async (
  note: Note,
): Promise<ExtededNote | null> => {
  console.log('Extended node');
  const result = await http<ExtededNote, Note>({
      path: `/notes`,
    method: "post",
    body: note,
  });
    console.log("ok", result.ok);
    console.log("body", result.body);
  if (result.ok && result.body) {
    return result.body;
  } else {
    return null;
  }
};

export const getOrbdNote = async (
    note: Note,
): Promise<ExtededNote | null> => {
    console.log('Extended ORB node');
    const result = await http<ExtededNote, Note>({
        path: `/orbital/GetExtendedNote`,
        method: "post",
        body: note,
    });
    console.log("ok", result.ok);
    console.log("body", result.body);
    if (result.ok && result.body) {
        return result.body;
    } else {
        return null;
    }
};


export const getFictiondNote = async (
    note: Note,
): Promise<ExtededNote | null> => {
    console.log('Extended node');
    const result = await http<ExtededNote, Note>({
        path: `/notes/fiction`,
        method: "post",
        body: note,
    });
    console.log("ok", result.ok);
    console.log("body", result.body);
    if (result.ok && result.body) {
        return result.body;
    } else {
        return null;
    }
};


export const nodeOrbClick = (): void => {
    console.log('nodeORBClick');
    const note = { Name: 'N', Description: 'd' };
    getOrbdNote(note);
    console.log('Node ORB Click');
};


export const nodeClick = (): void => {
    console.log('nodeClick');
    const note = { Name: 'N', Description: 'd' };
    getFictiondNote(note);
    console.log('Node Click');
};



