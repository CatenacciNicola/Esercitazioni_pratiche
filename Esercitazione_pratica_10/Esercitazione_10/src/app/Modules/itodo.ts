import { iUser } from "./iuser"

export type Root = iTodo[]

export interface iTodo {
  id: number
  todo: string
  completed: boolean
  userId: number
  user?:iUser
}
