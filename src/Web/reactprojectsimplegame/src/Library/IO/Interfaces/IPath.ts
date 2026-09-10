export interface IPath {

    pathCombine(path1: string, path2: string): string

    getFileName(fileName: string): string

    getFileExtension(fileName: string): string

    getFileNameWithoutExtension(fileName: string): string

    getDirectoryName(fileName: string): string

}