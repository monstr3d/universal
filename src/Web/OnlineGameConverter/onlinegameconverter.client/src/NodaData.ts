/* eslint-disable prettier/prettier */
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
