import { iTodo } from "./itodo"

export type Root = iUser[]

export interface iUser {
  id: number
  firstName: string
  lastName: string
  email: string
  image: string
  title: string
  Alltodo?:iTodo[]
}
